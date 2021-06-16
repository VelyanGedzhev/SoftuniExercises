using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Headers;
using WebServer.Server.Http.Cookies;

namespace WebServer.Server.Http
{
    public class HttpResponse
    {
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.AddHeader(HttpHeader.Server, "My web server");
            this.AddHeader(HttpHeader.Date, $"{DateTime.UtcNow:r}");
        }

        public HttpResponseStatusCode StatusCode { get; protected set; }

        public IDictionary<string, HttpHeader> Headers { get; } = new Dictionary<string, HttpHeader>(StringComparer.InvariantCultureIgnoreCase);

        public IDictionary<string, HttpCookie> Cookies { get; } = new Dictionary<string, HttpCookie>(StringComparer.InvariantCultureIgnoreCase);

        public byte[] Content { get; protected set; }

        public bool HasContent => this.Content != null && this.Content.Any();

        public static HttpResponse ForError(string message)
            => new HttpResponse(HttpResponseStatusCode.InternalServerError)
                .SetContent(message, HttpContentType.PlainText);

        public void AddHeader(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Headers[name] = new HttpHeader(name, value);
        }

        public void AddCookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Cookies[name] = new HttpCookie(name, value);
        }

        public HttpResponse SetContent(string content, string contentType)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            var contentLength = Encoding.UTF8.GetByteCount(content).ToString();

            this.AddHeader(HttpHeader.ContentType, contentType);
            this.AddHeader(HttpHeader.ContentLength, contentLength);

            this.Content = Encoding.UTF8.GetBytes(content);

            return this;
        }

        public HttpResponse SetContent(byte[] content, string contentType)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.AddHeader(HttpHeader.ContentType, contentType);
            this.AddHeader(HttpHeader.ContentLength, content.Length.ToString());

            this.Content = content;

            return this;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers.Values)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in this.Cookies.Values)
            {
                result.AppendLine($"{HttpHeader.SetCookie}: {cookie}");
            }

            if (this.HasContent)
            {
                result.AppendLine(); 
            }

            return result.ToString();
        }

    }
}
