using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebServer.Server.Enums;
using WebServer.Server.Http;
using WebServer.Server.Http.Sessions;
using WebServer.Server.Routing;

namespace WebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        private static Type httpResponseType = typeof(HttpResponse);
        private static Type stringType = typeof(string);

        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
                => routingTable.MapGet(path, request => controllerFunction(
                    CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
             => routingTable.MapPost(path, request => controllerFunction(
                    CreateController<TController>(request)));

        public static IRoutingTable MapControllers(
            this IRoutingTable routingTable)
        {
            var controllerActions = GetControllerActions();

            foreach (var controllerAction in controllerActions)
            {
                
                var controllerName = controllerAction.DeclaringType.GetControllerName();
                var actionName = controllerAction.Name;

                var path = $"/{controllerName}/{actionName}";

                var responseFunction = GetResponseFunction(controllerAction);

                var httpMethod = HttpRequestMethod.Get;

                var httpMethodAttribute = controllerAction
                    .GetCustomAttribute<HttpMethodAttribute>();

                if (httpMethodAttribute != null)
                {
                    httpMethod = httpMethodAttribute.HttpMethod;
                }

                routingTable.Map(httpMethod, path, responseFunction);

                MapDefualtRoutes(
                    routingTable, 
                    httpMethod, 
                    controllerName, 
                    actionName, 
                    responseFunction);
            }

            return routingTable;
        }

        private static IEnumerable<MethodInfo> GetControllerActions()
            => Assembly
            .GetEntryAssembly()
            .GetExportedTypes()
            .Where(t => !t.IsAbstract
                && t.IsAssignableTo(typeof(Controller))
                && t.Name.EndsWith(nameof(Controller)))
            .SelectMany(t => t
                .GetMethods(BindingFlags.Instance |BindingFlags.Public)
                .Where(m => m.ReturnType.IsAssignableTo(httpResponseType)))
            .ToList();

        private static Func<HttpRequest, HttpResponse> GetResponseFunction(MethodInfo controllerAction)
            => request =>
            {
                if (!UserIsAuthorized(controllerAction, request.Session))
                {
                    return new HttpResponse(HttpResponseStatusCode.Unauthorized);
                }

                var controllerInstance = CreateController(controllerAction.DeclaringType, request);

                var parameterValues = GetParametersValues(controllerAction, request);

                return (HttpResponse)controllerAction.Invoke(controllerInstance, parameterValues);
            };


        private static void MapDefualtRoutes(
            IRoutingTable routingTable,
            HttpRequestMethod httpMethod,
            string controllerName,
            string actionName,
            Func<HttpRequest, HttpResponse> responseFunction)
        {
            const string defaultActionName = "Index";
            const string defaultControllerName = "Home";

            if (actionName == defaultActionName)
            {
                routingTable.Map(httpMethod, $"/{controllerName}", responseFunction);

                if (controllerName == defaultControllerName)
                {
                    routingTable.Map(httpMethod, "/", responseFunction);
                }
            }
        }

        private static TController CreateController<TController>(HttpRequest request)
            where TController : Controller
            => (TController)CreateController(typeof(TController), request);

        private static Controller CreateController(Type controllerType, HttpRequest request)
        {
            var controller = (Controller)request.Services.CreateInstance(controllerType);

            controllerType
                .GetProperty("Request", 
                    BindingFlags.Instance | 
                    BindingFlags.NonPublic)
                .SetValue(controller, request);

            return controller;
        }

        private static bool UserIsAuthorized(
            MethodInfo controllerAction,
            HttpSession session)
        {
            var authorizationRequired = controllerAction
                 .DeclaringType
                 .GetCustomAttribute<AuthorizeAttribute>()
                  ?? controllerAction
                  .GetCustomAttribute<AuthorizeAttribute>();

            if (authorizationRequired != null)
            {
                var userIsAuthorized = session.Contains(Controller.UserSessionKey)
                    && session[Controller.UserSessionKey] != null;

                if (!userIsAuthorized)
                {
                    return false;
                }
            }

            return true;
        }

        private static object[] GetParametersValues(
            MethodInfo controllerAction,
            HttpRequest request)
        {
            var actionParameters = controllerAction
                    .GetParameters()
                    .Select(p => new
                    {
                        p.Name,
                        Type = p.ParameterType
                    })
                    .ToArray();

            var parameterValues = new object[actionParameters.Length];

            for (int i = 0; i < actionParameters.Length; i++)
            {
                var parameter = actionParameters[i];
                var parameterName = parameter.Name;
                var parameterType = parameter.Type;

                if (parameterType.IsPrimitive 
                    || parameterType == stringType)
                {
                    var parameterValue = request.GetValue(parameterName);
                    parameterValues[i] = Convert.ChangeType(parameterValue, parameterType);
                }
                else
                {
                    var parameterValue = Activator.CreateInstance(parameterType);

                    var parameterProperties = parameterType.GetProperties();

                    foreach (var prop in parameterProperties)
                    {
                        var propertyValue = request.GetValue(prop.Name);

                        prop.SetValue(
                            parameterValue, 
                            Convert.ChangeType(propertyValue, prop.PropertyType));
                    }

                    parameterValues[i] = parameterValue;
                } 

            }

            return parameterValues;
        }

        private static string GetValue(this HttpRequest request, string name)
            => request.Query.GetValueOrDefault(name) ??
                         request.Form.GetValueOrDefault(name);

        //private static object ConvertType(Type type, object value) 
        //    => type == stringType
        //        ? value
        //        : Convert.ChangeType(value, type);
    }
}
