using System.IO;
using System.Text;
using WebServer.Server.Enums;
using WebServer.Server.Http;

namespace WebServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName)
            : base(HttpResponseStatusCode.OK) 
            => this.GetHtml(viewName, controllerName);

        private void GetHtml(string viewName, string controllerName)
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

            this.PrepareContent(viewContent, HttpContentType.HtmlText);
            
        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpResponseStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.PrepareContent(errorMessage, HttpContentType.PlainText);
        }
    }
}
