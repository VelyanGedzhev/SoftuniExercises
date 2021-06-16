using System;
using System.Collections;
using System.Collections.Generic;

namespace WebServer.Server.Http.Collections
{
    public class FormCollection : IEnumerable<string>
    {
        private readonly Dictionary<string, string> forms;

        public FormCollection() 
            => this.forms = new(StringComparer.InvariantCultureIgnoreCase);

        public string this[string name]
            => this.forms[name];

        public void Add(string name, string value)
            => this.forms[name] = value;

        public bool Contains(string name)
            => this.forms.ContainsKey(name);

        public string GetValueOrDefault(string key)
             => this.forms.GetValueOrDefault(key);

        public IEnumerator<string> GetEnumerator()
            => forms.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
