namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesByKeys;

        public TreeFactory()
        {
            this.nodesByKeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] keys = line.Split()
                    .Select(int.Parse)
                    .ToArray();

                int parentKey = keys[0];
                int childKey = keys[1];

                AddEdge(parentKey, childKey);
            }

            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesByKeys.ContainsKey(key))
            {
                this.nodesByKeys.Add(key, new Tree<int>(key));
            }

            return this.nodesByKeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var kvp in this.nodesByKeys)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
