using WebServer.Server.Controllers;
using WebServer.Server.Http;
using WebServer.Server.Results;

namespace WebServer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request) 
            : base(request)
        {
        }

        public ActionResult ActionWithCookies()
        {
            const string CookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(CookieName))
            {
                var cookie = this.Request.Cookies[CookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.AddCookie(CookieName, "My-value");
            this.Response.AddCookie("My-Second-Cookie", "My-Second-value");

            return Text("Cookies set!");
        }
    }
}
