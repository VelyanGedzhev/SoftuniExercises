using System.Collections.Generic;

namespace WebServer.HTTP.Headers
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection() => this.headers = new Dictionary<string, HttpHeader>();

        public void Add(HttpHeader httpHeader) =>
            this.headers.Add(httpHeader.Name, httpHeader);

        public int Count => this.headers.Count;
    }
}
