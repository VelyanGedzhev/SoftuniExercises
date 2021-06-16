using System;
using System.Collections;
using System.Collections.Generic;

namespace WebServer.Server.Http.Collections
{
    public class QueryCollection : IEnumerable<string>
    {
        private readonly Dictionary<string, string> queries;

        public QueryCollection()
            => this.queries = new(StringComparer.InvariantCultureIgnoreCase);


        public string this[string name]
            => this.queries[name];

        public void Add(string name, string value)
            => this.queries[name] = value;

        public bool Contains(string name)
            => this.queries.ContainsKey(name);

        public string GetValueOrDefault(string key)
             => this.queries.GetValueOrDefault(key);

        public IEnumerator<string> GetEnumerator()
            => queries.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
