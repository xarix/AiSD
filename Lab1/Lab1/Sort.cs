using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Sort
    {

        public const string ASCENDING = "Asc";
        public const string DESCENDING = "Desc";
        public const string ASHAPED = "AShape";
        public const string VSHAPED = "VShape";
        public const string RANDOM = "Random";
        public const string CONSTANT = "Const";
        public const string INSERTION = "Insertion";
        public const string SELECTION = "Selection";
        public const string HEAP = "Heap";
        public const string QUICKSORT_RIGHT = "QuickIterativeRight";
        public const string QUICKSORT_MIDDLE = "QuickIterativeMiddle";
        public const string QUICKSORT_RANDOM = "QuickIteraticeRandom";
        public const string QUICKSORT_RECURSIVE = "QuickRecursive";
        public const string RIGHT = "Right";
        public const string MIDDLE = "Mid";

        public static int[] SortArray(int[] A, string type) {
            return type switch {
                SELECTION => SelectionSort(A),
                INSERTION => InsertionSort(A),
                HEAP => HeapSort(A),
                QUICKSORT_RIGHT => QuickSortIterative(A, RIGHT),
                QUICKSORT_MIDDLE => QuickSortIterative(A, MIDDLE),
                QUICKSORT_RANDOM => QuickSortIterative(A, RANDOM),
                QUICKSORT_RECURSIVE => QuickSortMain(A),
                _ => throw new ArgumentException("Algorithm doesn't exist!"),
            };
        }

        public static int[] InsertionSort(int[] A)
        {
            for (var j = 1; j < A.Length; j++)
            {
                var key = A[j];
                var i = j - 1;
                while(i >= 0 && A[i] > key)
                {
                    A[i + 1] = A[i];
                    i--;
                }
                A[i + 1] = key;
            }

            return A;
        }

        public static int[] SelectionSort(int[] A)
        {
            for (var j = A.Length - 1; j > 0; j--)
            {
                var max = j;
                for (var i = j - 1; i >= 0; i--)
                {
                    if(A[i] > A[max])
                    {
                        max = i;
                    }
                }
                var tmp = A[j];
                A[j] = A[max];
                A[max] = tmp;
            }

            return A;
        }

        public static int[] HeapSort(int[] A)
        {
            BuildHeap(A);
            var heapSize = A.Length - 1;
            for(var i = A.Length -1; i > 0; i--)
            {
                var tmp = A[0];
                A[0] = A[i];
                A[i] = tmp;
                heapSize--;
                Heapify(A, 0, heapSize);
            }

            return A;
        }

        private static void Heapify(int[] A, int i, int heapSize)
        {
            var l = i * 2;
            var r = (i * 2) + 1;
            int largest;
            if(l <= heapSize && A[l] > A[i])
            {
                largest = l;
            }
            else
            {
                largest = i;
            }
            if(r <= heapSize && A[r] > A[largest])
            {
                largest = r;
            }
            if(largest != i)
            {
                var tmp = A[i];
                A[i] = A[largest];
                A[largest] = tmp;
                Heapify(A, largest, heapSize);
            }
        }

        private static void BuildHeap(int[] A)
        {
            var heapSize = A.Length - 1;
            for(var i = A.Length / 2; i >= 0; i--) 
            {
                Heapify(A, i, heapSize); 
            }
        }

        public static int[] QuickSortMain(int[] A)
        {
            QuickSort(A, 0, A.Length - 1);
            return A;
        }

        private static void QuickSort(int[] A, int p, int r)
        {
            if(p < r)
            {
                var q = Partition(A, p, r);
                QuickSort(A, p, q);
                QuickSort(A, q + 1, r);
            }
        }

        private static int Partition(int[] A, int p, int r)
        {
            var x = A[(p + r) / 2];
            var i = p - 1;
            var j = r + 1;
            while (true)
            {
                do
                {
                    j--;
                } while (A[j] > x);
                do
                {
                    i++;
                } while (A[i] < x);
                if(i < j)
                {
                    var tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                }
                else
                {
                    return j;
                }
            }
        }

        public static int[] QuickSortIterative(int[] A, string pivot)
        {
            Stack stack = new Stack(A.Length - 1);
            int left = 0;
            int right = A.Length - 1;
            int i, j, x, tmp = 0;
            Pair stackItem;

            stack.Push(new Pair( 0, A.Length - 1));
            do
            {
                stackItem = stack.Pop();
                left = stackItem.left;
                right = stackItem.right;
                do
                {
                    i = left;
                    j = right;
                    x = pivot switch
                    {
                        RIGHT => A[right],
                        MIDDLE => A[(left + right) / 2],
                        RANDOM => A[new Random().Next(left, right)],
                        _ => throw new ArgumentException(),
                    };
                    do
                    {
                        while (A[i] < x) { i++; }
                        while (A[j] > x) { j--; }
                        if(i <= j)
                        {
                            tmp = A[i];
                            A[i] = A[j];
                            A[j] = tmp;
                            i++;
                            j--;
                        }
                    } while (i <= j);
                    if(i < right)
                    {
                        stack.Push(new Pair(i, right));
                    }
                    right = j;
                } while (left < right);
                   
            } while (!stack.IsEmpty());

            return A;
        }
    }
}
