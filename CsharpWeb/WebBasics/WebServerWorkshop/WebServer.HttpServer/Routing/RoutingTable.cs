using System;
using System.Collections.Generic;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Http;
using WebServer.Server.Responses;

namespace WebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
            => this.routes = new()
            {
                [HttpRequestMethod.Get] = new(),
                [HttpRequestMethod.Post] = new(),
                [HttpRequestMethod.Put] = new(),
                [HttpRequestMethod.Delete] = new()
            };

        public IRoutingTable Map(
           HttpRequestMethod method,
           string path,
           HttpResponse response)
        {
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }

        public IRoutingTable Map(HttpRequestMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response) 
            => MapGet(path, request => response);


        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => Map(HttpRequestMethod.Get, path, responseFunction);

        public IRoutingTable MapPost(string path, HttpResponse response) 
            => MapPost(path, requests=> response);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => Map(HttpRequestMethod.Post, path, responseFunction);

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}
