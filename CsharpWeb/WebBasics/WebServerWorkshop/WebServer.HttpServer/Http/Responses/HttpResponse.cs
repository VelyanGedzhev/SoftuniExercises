﻿using System;
using System.Text;
using WebServer.Server.Common;
using WebServer.Server.Enums;
using WebServer.Server.Headers;

namespace WebServer.Server.Responses
{
    public abstract class HttpResponse
    {
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add("Server", "My web server");
            this.Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }

        public HttpResponseStatusCode StatusCode { get; protected set; }

        public HttpHeaderCollection Headers { get; } = new HttpHeaderCollection();

        public string Content { get; protected set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();
                result.Append(this.Content);
            }

            return result.ToString();
        }

        protected void PrepareContent(string content, string contentType)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            var contentLength = Encoding.UTF8.GetByteCount(content).ToString();

            this.Headers.Add("Content-Type: ", contentType);
            this.Headers.Add("Content-Length: ", contentLength);

            this.Content = content;
        }
    }
}
