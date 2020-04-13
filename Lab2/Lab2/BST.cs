using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class BST : IDataType
    {
        private BSTNode root;

        public BST()
        {

        }

        public BST(int value) => root = new BSTNode(value);

        public BST(IEnumerable<int> enumerable)
        {
            foreach (var item in enumerable)
            {
                Insert(item);
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

        public int MeasureSearchTime(int[] array)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int element in array) 
            {
                Search(element);
            }
            stopwatch.Stop();
            return (int)stopwatch.ElapsedMilliseconds;
        }

        public int MeasureDestroyTime()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            PostorderDelete(root);
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


        private BSTNode Insert(BSTNode root, int value)
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

        public void PostorderDelete(BSTNode node)
        {
            if (node != null)
            {
                PostorderDelete(node.Left);
                PostorderDelete(node.Right);
                node = null;
            }
        }

        public void BuildAVL()
        {
            var sortedListOfNodes = new List<BSTNode>();
            InOrderList(root, sortedListOfNodes);
            root = null;
            BuildAVL(sortedListOfNodes, 0, sortedListOfNodes.Count);
        }

        private void BuildAVL(List<BSTNode> list, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            var mid = (left + right) / 2;
            Insert(list[mid].Value);
            BuildAVL(list, left, mid);
            BuildAVL(list, mid + 1, right);
        }

        private void InOrderList(BSTNode root, List<BSTNode> list)
        {
            if (root != null)
            {
                InOrderList(root.Left, list);
                list.Add(root);
                InOrderList(root.Right, list);
            }

            return;
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
