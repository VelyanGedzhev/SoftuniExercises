﻿using System.Runtime.CompilerServices;
using WebServer.Server.Enums;
using WebServer.Server.Http;
using WebServer.Server.Identity;
using WebServer.Server.Results;

namespace WebServer.Server.Controllers
{
    public abstract class Controller
    {
        public const string UserSessionKey = "AuthenticatedUserId";

        private UserIdentity userIdentity;

        protected HttpRequest Request { get; init;}

        protected HttpResponse Response { get; private init;} = new HttpResponse(HttpResponseStatusCode.OK);

        protected UserIdentity User
        {
            get
            {
                if (this.userIdentity == null)
                {
                    this.userIdentity = this.Request.Session.Contains(UserSessionKey)
                        ? new UserIdentity { Id = this.Request.Session[UserSessionKey] }
                        : new();
                }

                return this.userIdentity;
            }
        }

        protected void SignIn(string userId)
        {
            this.Request.Session[UserSessionKey] = userId;
            this.userIdentity = new UserIdentity { Id = userId };
        }

        protected void SignOut()
        {
            this.Request.Session.Remove(UserSessionKey);
            this.userIdentity = new UserIdentity();
        }
        protected ActionResult Text(string text)
            => new TextResult(this.Response, text);

        protected ActionResult Html(string html)
            => new HtmlResult(this.Response, html);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response, location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), null);

        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, this.GetType().GetControllerName(), model);

    }
}
