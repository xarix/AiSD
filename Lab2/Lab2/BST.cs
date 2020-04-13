using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class BST : IDataType
    {
        BSTNode root;

        public BST()
        {

        }

        public BST(int value)
        {
            root = new BSTNode(value);
        }

        public BST(IEnumerable<int> enumerable)
        {
            foreach (var item in enumerable)
            {
                Insert(root, item);
            }
        }

        public int MeasureInsertTime(int[] array)
        {
            var stopwatch = new Stopwatch();
            array = (int[])array.Clone();
            stopwatch.Start();
            foreach (int element in array) {
                Insert(element);
            }
            stopwatch.Stop();
            return (int)stopwatch.ElapsedMilliseconds;
        }

        public void Insert(int value)
        {
            if (root is null)
            {
                root = new BSTNode(value);
                return;
            }
            Insert(root, value);
        }


        public BSTNode Insert(BSTNode root, int value)
        {
            if (root is null)
            {
                return new BSTNode(value);
            }
            else if (value < root.Value){
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        public BSTNode Search(int value) => Search(root, value);

        private BSTNode Search(BSTNode root, int value)
        {
            if (root is null || value == root.Value)
            {
                return root;
            }
            else if (value < root.Value)
            {
                return Search(root.Left, value);
            }
            else
            {
                return Search(root.Right, value);
            }
        }

        public int Height()
        {
            if (root is null)
            {
                return 0;
            }
            return Height(root) -1;
        }

        private int Height(BSTNode root)
        {
            if (root is null)
            {
                return 0;
            }
            return 1 + Math.Max(Height(root.Left), Height(root.Right));
        }

        public BSTNode BuildAVL()
        {
            return null;
        }

        public void PrintInorder() => PrintInorder(root);

        private void PrintInorder(BSTNode root)
        {
            if (root != null)
            {
                PrintInorder(root.Left);
                Console.WriteLine(root.Value);
                PrintInorder(root.Right);
            }
        }

        public void PrintPostorder() => PrintPostorder(root);

        private void PrintPostorder(BSTNode root)
        {
            if (root != null)
            {
                PrintInorder(root.Left);
                PrintInorder(root.Right);
                Console.WriteLine(root.Value);
            }
        }

        public void PrintPreorder() => PrintPreorder(root);

        private void PrintPreorder(BSTNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Value);
                PrintInorder(root.Left);
                PrintInorder(root.Right);
            }
        }
    }
}
