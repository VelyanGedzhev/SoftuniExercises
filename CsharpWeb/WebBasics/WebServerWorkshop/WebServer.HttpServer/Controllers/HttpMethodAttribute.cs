using System;
using WebServer.Server.Enums;

namespace WebServer.Server.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {

        protected HttpMethodAttribute(HttpRequestMethod httpMethod) 
            => this.HttpMethod = httpMethod;

        public HttpRequestMethod HttpMethod { get; }
    }
}
