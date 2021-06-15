using WebServer.Server.Enums;

namespace WebServer.Server.Controllers
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute() 
            : base(HttpRequestMethod.Post)
        {
        }
    }
}
