namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder result = new StringBuilder();

            DfsOrder(0, result, this);

            return result.ToString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftMostNode()
        {
            Func<Tree<T>, bool> leafNodePredicate = (node)
                 => IsLeafNode(node);

            var leafNodes = OrderBfsNodes(leafNodePredicate);
            int deepestNodeDepth = 0;
            Tree<T> deepestLeaf = null;

            foreach (var leaf in leafNodes)
            {
                int currentDepth = GetDepthFromLeafParent(leaf);

                if (currentDepth > deepestNodeDepth)
                {
                    deepestNodeDepth = currentDepth;
                    deepestLeaf = leaf;
                }
            }

            return deepestLeaf;

        }

        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> leafNodePredicate = (node)
                => IsLeafNode(node);

            return OrderBfs(leafNodePredicate);
        }


        public List<T> GetMiddleKeys()
        {
            Func<Tree<T>, bool> middleNodePredicate = (node)
                => IsMiddleNode(node);

            return OrderBfs(middleNodePredicate);
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = GetDeepestLeftMostNode();
            var result = new Stack<T>();
            var currentNode = deepestNode;

            while (currentNode != null)
            {
                result.Push(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            return new List<T>(result);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            int currentSum = Convert.ToInt32(this.Key);
            var currentPath = new List<T>();
            currentPath.Add(this.Key);

            GetPathWithSumDfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var subtreesWithGivenSum = new List<Tree<T>>();
            var allNodes = OrderBfsNodes();

            foreach (var node in allNodes)
            {
                int currentSubtreeSum = GetSubtreeSumDfs(node);

                if (currentSubtreeSum == sum)
                {
                    subtreesWithGivenSum.Add(node);
                }
            }

            return subtreesWithGivenSum;
        }

        private void DfsOrder(int depth, StringBuilder result, Tree<T> subTree)
        {
            result
                .AppendLine(new string(' ', depth) + subTree.Key);

            foreach (var child in subTree.Children)
            {
                DfsOrder(depth + 2, result, child);
            }
        }

        private bool IsLeafNode(Tree<T> node)
        {
            return node.Children.Count == 0;
        }

        private bool IsRootNode(Tree<T> node)
        {
            return node.Parent == null;
        }

        private bool IsMiddleNode(Tree<T> node)
        {
            return !IsLeafNode(node) && !IsRootNode(node);
        }

        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<T>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Any())
            {
                var currentNode = nodes.Dequeue();

                if (predicate.Invoke(currentNode))
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfsNodes(Func<Tree<T>, bool> predicate = null)
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Any())
            {
                var currentNode = nodes.Dequeue();

                if (predicate != null)
                {

                    if (predicate.Invoke(currentNode))
                    {
                        result.Add(currentNode);
                    }
                }
                else
                {
                    result.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private int GetDepthFromLeafParent(Tree<T> leaf)
        {
            int level = 0;
            Tree<T> currentNode = leaf;

            while (currentNode.Parent != null)
            {
                level++;
                currentNode = currentNode.Parent;
            }

            return level;
        }


        private void GetPathWithSumDfs(
            Tree<T> current, 
            List<List<T>> result, 
            List<T> currentPath, 
            ref int currentSum, 
            int sum)
        {
            foreach (var child in current.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);

                GetPathWithSumDfs(child, result, currentPath, ref currentSum, sum);
            }

            if (currentSum == sum)
            {
                result.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(current.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }


        private int GetSubtreeSumDfs(Tree<T> currentNode)
        {
            int currentSum = Convert.ToInt32(currentNode.Key);
            int childSum = 0;

            foreach (var childNode in currentNode.Children)
            {
                childSum += GetSubtreeSumDfs(childNode);
            }

            return childSum + currentSum;
        }
    }
}
