using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class BST
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
            else if (value < root.value){
                root.left = Insert(root.left, value);
            }
            else
            {
                root.right = Insert(root.right, value);
            }

            return root;
        }

        public BSTNode Search(int value) => Search(root, value);

        private BSTNode Search(BSTNode root, int value)
        {
            if (root is null || value == root.value)
            {
                return root;
            }
            else if (value < root.value)
            {
                return Search(root.left, value);
            }
            else
            {
                return Search(root.right, value);
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
            return 1 + Math.Max(Height(root.left), Height(root.right));
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
                PrintInorder(root.left);
                Console.WriteLine(root.value);
                PrintInorder(root.right);
            }
        }

        public void PrintPostorder() => PrintPostorder(root);

        private void PrintPostorder(BSTNode root)
        {
            if (root != null)
            {
                PrintInorder(root.left);
                PrintInorder(root.right);
                Console.WriteLine(root.value);
            }
        }

        public void PrintPreorder() => PrintPreorder(root);

        private void PrintPreorder(BSTNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.value);
                PrintInorder(root.left);
                PrintInorder(root.right);
            }
        }
    }
}
