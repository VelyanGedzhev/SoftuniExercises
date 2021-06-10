﻿using System.IO;
using System.Linq;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Http;

namespace WebServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model)
            : base(HttpResponseStatusCode.OK) 
            => this.GetHtml(viewName, controllerName, model);

        private void GetHtml(string viewName, string controllerName, object model)
        {

            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath("./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissingViewError(viewPath);
                return;
            }

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.PrepareContent(viewContent, HttpContentType.HtmlText);
            
        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpResponseStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    Name = pr.Name,
                    Value = pr.GetValue(model)
                });

            foreach (var entry in data)
            {
                const string openingBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
