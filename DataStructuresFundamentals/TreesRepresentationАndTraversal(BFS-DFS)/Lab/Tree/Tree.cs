namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            if (IsRootDeleted)
            {
                return result;
            }

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

            Dfs(this, result);
            return result;

            //return OrderDfsWithStack();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindBfs(parentKey);
            CheckEmptyNode(parentNode);
            parentNode._children.Add(child);

            //var parentNode = this.FindDfs(parentKey, this);
        }

        public void RemoveNode(T nodeKey)
        {
            var currentNode = FindBfs(nodeKey);
            CheckEmptyNode(currentNode);

            foreach (var child in currentNode.Children)
            {
                child.Parent = null;
            }

            currentNode._children.Clear();

            var parentNode = currentNode.Parent;

            if (parentNode is null)
            {
                IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(currentNode);
                currentNode.Parent = null;
            }

            currentNode.Value = default(T);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindBfs(firstKey);
            var secondNode = FindBfs(secondKey);

            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            if (secondParent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();
            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);

            while(toTraverse.Count > 0)
            {
                var subtree = toTraverse.Pop();

                foreach (var child in subtree.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(subtree.Value);
            }

            return new List<T>(result);
        }

        private Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(value))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        //O(n)
        private Tree<T> FindDfs(T value, Tree<T> subtree)
        {
            foreach (var child in subtree.Children)
            {
                Tree<T> current = this.FindDfs(value, child);

                if (current != null &&
                    current.Value.Equals(value))
                {
                    return current;
                }
            }

            if (subtree.Value.Equals(value))
            {
                return subtree;
            }

            return null;
        }

        private void CheckEmptyNode(Tree<T> parentNode)
        {
            if (parentNode is null)
            {
                throw new ArgumentNullException("Searched node not found");
            }
        }

        private void SwapRoot(Tree<T> node)
        {
            Value = node.Value;
            this._children.Clear();

            foreach (var child in node.Children)
            {
                this._children.Add(child);
            }
        }
    }
}
