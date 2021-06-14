using System;
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


        public HttpResponse Login()
        {
            // var user = this.db.Users.Find(username, password);

            // if(user != null)
            // {
            //    this.SignIn(user.Id);
            //    return Text("User is logged in!");
            // }

            // return Text("Invalid credentials!");

            var someUserId = "MyUserId"; //should come from the DB
            this.SignIn(someUserId);

            return Text("User authenticated!");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return Text("User signed out!");
        }

        public HttpResponse AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user: {this.User.Id}");
            }
            else
            {
                return Text("User is not authenticated!");
            }
        }

        public ActionResult CookiesCheck()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}!");
            }

            this.Response.AddCookie(cookieName, "My-value");
            this.Response.AddCookie("My-Second-Cookie", "My-Second-value");

            return Text("Cookies set!");
        }

        public ActionResult SessionCheck()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var currentDate = this.Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}!");
            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return Text("Current date stored!");
        }
    }
}
