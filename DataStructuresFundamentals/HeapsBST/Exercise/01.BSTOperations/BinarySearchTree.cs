namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Copy(root);
        }


        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => Root.Value;

        public int Count => Root.Count;

        public bool Contains(T element)
        {
            var current = Root;

            while (current != null)
            {
                if (IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            var toInsert = new Node<T>(element, null, null);

            if (Root == null)
            {
                Root = toInsert;
            }
            else
            {
                InsertElementDfs(Root, null, toInsert);
            }
            
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = Root;

            while (current != null)
            {
                if (IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    break;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrderDfs(Root, action);
        }

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();
            var nodes = new Queue<Node<T>>();

            nodes.Enqueue(Root);

            while (nodes.Count > 0)
            {
                var current = nodes.Dequeue();

                if (IsLess(lower, current.Value) &&
                    IsGreater(upper, current.Value))
                {
                    result.Add(current.Value);
                }
                else if (AreEqual(lower, current.Value) ||
                    AreEqual(upper, current.Value))
                {
                    result.Add(current.Value);
                }

                if (current.LeftChild != null)
                {
                    nodes.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    nodes.Enqueue(current.RightChild);
                }
            }


            return result;
        }

        public void DeleteMin()
        {
            EnsureNotEmpty();

            var current = Root;
            Node<T> previous = null;

            if (Root.LeftChild == null)
            {
                Root = Root.RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }
            
        }

        public void DeleteMax()
        {
            EnsureNotEmpty();
            var current = Root;
            Node<T> previous = null;

            if (Root.RightChild == null)
            {
                Root = Root.LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return GetRankDfs(Root, element);
        }

        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (IsLess(element, current.Value))
            {
                return GetRankDfs(current.LeftChild, element);
            }
            else if (AreEqual(element, current.Value))
            {
                return GetNodeCount(current);
            }

            return GetNodeCount(current.LeftChild) 
                + 1 + GetRankDfs(current.RightChild, element);
        }

        private int GetNodeCount(Node<T> current)
        {
            return current == null ? 0 : current.Count;
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                Insert(current.Value);
                Copy(current.LeftChild);
                Copy(current.RightChild);
            }
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                EachInOrderDfs(current.RightChild, action);
            }
        }

        private void InsertElementDfs(
             Node<T> current,
             Node<T> previous,
             Node<T> toInsert)
        {
            if (current == null &&
                IsLess(toInsert.Value, previous.Value))
            {
                previous.LeftChild = toInsert;

                if (LeftChild == null)
                {
                    LeftChild = toInsert;
                }

                return;
            }

            if (current == null &&
                IsGreater(toInsert.Value, previous.Value))
            {
                previous.RightChild = toInsert;

                if (RightChild == null)
                {
                    RightChild = toInsert;
                }

                return;
            }

            if (IsLess(toInsert.Value, current.Value))
            {
                InsertElementDfs(current.LeftChild, current, toInsert);
                current.Count++;
            }
            else if (IsGreater(toInsert.Value, current.Value))
            {
                InsertElementDfs(current.RightChild, current, toInsert);
                current.Count++;
            }
        }

        private bool IsLess(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }

        private bool IsGreater(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) > 0;
        }

        private bool AreEqual(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) == 0;
        }
        private void EnsureNotEmpty()
        {
            if (Root == null)
            {
                throw new InvalidOperationException("BST is empty");
            }
        }
    }
}
