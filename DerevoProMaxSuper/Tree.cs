using System;
using System.Collections;
using System.Collections.Generic;

namespace DerevoProMaxSuper
{

    public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> root;

        public void Add(T data)
        {
            if (root == null)
            {
                root = new Node<T>(data);
            }
            else
            {
                AddRecursive(root, data);
            }
        }

        public void AddRecursive(Node<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                }
                else
                {
                    AddRecursive(node.Left, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
                }
                else
                {
                    AddRecursive(node.Right, data);
                }
            }
        }

        public Node<T> Search(T data)
        {
            return SearchRecursive(root, data);
        }

        public Node<T> SearchRecursive(Node<T> node, T data)
        {
            if (node == null || data.CompareTo(node.Data) == 0)
            {
                return node;
            }

            if (data.CompareTo(node.Data) < 0)
            {
                return SearchRecursive(node.Left, data);
            }
            else
            {
                return SearchRecursive(node.Right, data);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return BreadthFirstTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

         IEnumerable<T> BreadthFirstTraversal()
        {
            if (root == null)
                yield break;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> current = queue.Dequeue();
                yield return current.Data;

                if (current.Left != null)
                    queue.Enqueue(current.Left);

                if (current.Right != null)
                    queue.Enqueue(current.Right);
            }
        }
    }
}
