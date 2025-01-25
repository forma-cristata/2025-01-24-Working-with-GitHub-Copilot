using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public AVLTreeNode<T>? Root { get; set; }
        public void Insert(T value)
        {
            Root = Insert(Root!, value);
        }
        public AVLTreeNode<T> Insert(AVLTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return new AVLTreeNode<T>(value);
            }
            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left!, value);
            }
            else
            {
                node.Right = Insert(node.Right!, value);
            }
            node.Height = 1 + Math.Max(Height(node.Left!), Height(node.Right!));
            return Balance(node);
        }

        public AVLTreeNode<T> Balance(AVLTreeNode<T> node)
        {
            if (BalanceFactor(node) > 1)
            {
                if (BalanceFactor(node.Right!) < 0)
                {
                    node.Right = RotateRight(node.Right!);
                }
                node = RotateLeft(node);
            }
            else if (BalanceFactor(node) < -1)
            {
                if (BalanceFactor(node.Left!) > 0)
                {
                    node.Left = RotateLeft(node.Left!);
                }
                node = RotateRight(node);
            }
            return node;
        }

        public AVLTreeNode<T> RotateRight(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> newRoot = node.Left!;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            node.Height = 1 + Math.Max(Height(node.Left!), Height(node.Right!));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left!), Height(newRoot.Right!));
            return newRoot;
        }

        public AVLTreeNode<T> RotateLeft(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> newRoot = node.Right!;
            node.Right = newRoot.Left!;
            newRoot.Left = node;
            node.Height = 1 + Math.Max(Height(node.Left!), Height(node.Right!));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left), Height(newRoot.Right!));
            return newRoot;
        }

        public int BalanceFactor(AVLTreeNode<T> node)
        {
            return Height(node.Right!) - Height(node.Left!);
        }

        public int Height(AVLTreeNode<T> node)
        {
            return node == null ? 0 : node.Height;
        }

        public bool Search(T value)
        {
            return Search(Root!, value);
        }

        public bool Search(AVLTreeNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }
            if (value.CompareTo(node.Value) == 0)
            {
                return true;
            }
            if (value.CompareTo(node.Value) < 0)
            {
                return Search(node.Left!, value);
            }
            return Search(node.Right!, value);
        }

        public void PrintInOrder()
        {
            PrintInOrder(Root!);
        }

        public void PrintInOrder(AVLTreeNode<T> node)
        {
            if (node != null)
            {
                PrintInOrder(node.Left!);
                Console.WriteLine(node.Value);
                PrintInOrder(node.Right!);
            }
        }

        public void Remove(T value)
        {
            Root = Remove(Root, value);
        }

        public AVLTreeNode<T>? Remove(AVLTreeNode<T>? node, T value)
        {
            if (node == null)
            {
                return null;
            }
            if (value.CompareTo(node.Value) == 0)
            {
                if (node.Left == null)
                {
                    return node.Right;
                }
                if (node.Right == null)
                {
                    return node.Left;
                }
                T min = MinValue(node.Right);
                node.Value = min;
                node.Right = Remove(node.Right, min);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Remove(node.Left, value);
            }
            else
            {
                node.Right = Remove(node.Right, value);
            }
            node.Height = 1 + Math.Max(Height(node.Left!), Height(node.Right!));
            return Balance(node);
        }

        public T MinValue(AVLTreeNode<T> node)
        {
            T min = node.Value;
            while (node.Left != null)
            {
                min = node.Left.Value;
                node = node.Left;
            }
            return min;
        }
        public class AVLTreeNode<TNode> where TNode : IComparable<TNode>
        {
            public TNode Value { get; set; }
            public AVLTreeNode<TNode>? Left { get; set; } = null;
            public AVLTreeNode<TNode>? Right { get; set; } = null;
            public int Height { get; set; }

            public AVLTreeNode(TNode value)
            {
                Value = value;
                Height = 1;
            }
        }
    }
}