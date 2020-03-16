using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public static class Sort
    {
         //INSERTION-SORT(A)
         //1  for j = 2 to length[A]
         //2     do key = A[j]
         //3        Wstaw A[j] w posortowany ciąg A[1..j - 1]
         //4        i = j - 1
         //5        while (i > 0) i(A[i] > key)
         //6           do A[i + 1] = A[i]
         //7              i = i - 1
         //8        A[i + 1] = key
         //9  return A

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

         //SELECTION-SORT(A)
         //1  for j = length[A] downto 2
         //2     do max = j
         //3        for i = j - 1 downto 1
         //4           do if A[i] > A[max]
         //5               then max = i
         //6        zamień A[j] <-> A[max] 
         //7  return A

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
        
        
        //HEAPSORT(A)
        // 1  BUILD-HEAP(A)
        // 2  heapsize = length[A]
        // 3  for i = length[A] downto 2
        // 4     do zamień A[1] <-> A[i] 
        // 5        heapsize = heapsize - 1
        // 6        HEAPIFY(A, 1, heapsize)
        // 7  return A

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

        // HEAPIFY(A, i, heapsize)
        // 1  l = 2 • i
        // 2  r = (2 • i) + 1
        // 3  if (l <= heapsize) i(A[l] > A[i])
        // 4   then largest = l
        // 5   else largest = i
        // 6  if (r <= heapsize) i(A[r] > A[largest])
        // 7   then largest = r
        // 8  if largest<> i
        // 9   then zamień A[i] <-> A[largest] 
        //10        HEAPIFY(A, largest, heapsize)
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
        // BUILD-HEAP(A)
        // 1  heapsize = length[A]
        // 2  for i = length[A] / 2 downto 1
        // 3     do HEAPIFY(A, i, heapsize)
        private static void BuildHeap(int[] A)
        {
            var heapSize = A.Length - 1;
            for(var i = A.Length / 2; i >= 0; i--) 
            {
                Heapify(A, i, heapSize); 
            }
        }

        // QUICKSORT-MAIN(A)
        // 1  QUICKSORT(A, 1, length[A])
        // 2  return A
        public static int[] QuickSortMain(int[] A)
        {
            QuickSort(A, 0, A.Length - 1);
            return A;
        }

        // QUICKSORT(A, p, r)
        // 1  if p<r
        // 2   then q = PARTITION(A, p, r)
        // 3        QUICKSORT(A, p, q)
        // 4        QUICKSORT(A, q + 1, r)
        private static void QuickSort(int[] A, int p, int r)
        {
            if(p < r)
            {
                var q = Partition(A, p, r);
                QuickSort(A, p, q);
                QuickSort(A, q + 1, r);
            }
        }

        // PARTITION(A, p, r)
        // 1  x = A[(p + r) / 2]
        // 2  i = p - 1
        // 3  j = r + 1
        // 4  while True
        // 5     do repeat
        // 6              j = j - 1
        // 7        until A[j] <= x
        // 8        repeat
        // 9              i = i + 1
        //10        until A[i] >= x
        //11        if i<j
        //12         then zamień A[i] <-> A[j] 
        //13         else return j

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
                } while (A[j] <= x);
                do
                {
                    i++;
                } while (A[i] >= x);
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
    }
}
