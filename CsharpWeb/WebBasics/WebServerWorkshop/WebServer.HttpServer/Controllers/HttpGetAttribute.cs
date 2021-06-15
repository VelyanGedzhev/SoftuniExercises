using WebServer.Server.Enums;

namespace WebServer.Server.Controllers
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute() 
            : base(HttpRequestMethod.Get)
        {
        }
    }
}
