using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.HTTP.Headers.Contracts;

namespace WebServer.HTTP.Headers
{
    public class HttpHeader : IHttpHeader
    {
        public string Name { get; init; }

        public string Value { get; init; }
    }
}
