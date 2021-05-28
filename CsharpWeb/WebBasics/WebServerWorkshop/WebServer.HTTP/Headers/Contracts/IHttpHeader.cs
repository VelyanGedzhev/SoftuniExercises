using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.HTTP.Headers.Contracts
{
    public interface IHttpHeader
    {
        public string Name { get; }

        public string Value { get; }

    }
}
