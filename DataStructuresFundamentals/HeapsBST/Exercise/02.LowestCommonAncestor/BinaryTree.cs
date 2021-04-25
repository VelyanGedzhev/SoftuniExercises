namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;
            RightChild = rightChild;
            LeftChild = leftChild;

            if (RightChild != null)
            {
                RightChild.Parent = this;
            }

            if (LeftChild != null)
            {
                LeftChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstList = new List<BinaryTree<T>>();
            var secondList = new List<BinaryTree<T>>();

            FindNodeDfs(this, first, firstList);
            FindNodeDfs(this, second, secondList);

            var firstNode = firstList[0];
            var secondNode = secondList[0];

            var parentToLookFor = firstNode.Parent.Value;

            while (!parentToLookFor.Equals(firstNode.Value)
                || !parentToLookFor.Equals(secondNode.Value))
            {
                if (!parentToLookFor.Equals(firstNode.Value))
                {
                    firstNode = firstNode.Parent;
                }

                if (!parentToLookFor.Equals(secondNode.Value))
                {
                    secondNode = secondNode.Parent;
                }
            }

            return firstNode.Value;
        }

        private void FindNodeDfs(
            BinaryTree<T> current, 
            T lookupValue, 
            List<BinaryTree<T>> nodesList)
        {
            if (current == null)
            {
                return;
            }

            if (current.Value.Equals(lookupValue))
            {
                nodesList.Add(current);
                return;
            }

            FindNodeDfs(current.LeftChild, lookupValue, nodesList);
            FindNodeDfs(current.RightChild, lookupValue, nodesList);
        }
    }
}
