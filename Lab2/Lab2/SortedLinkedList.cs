using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class SortedLinkedList : IDataType
    {
        private ListNode head;

        public SortedLinkedList()
        {

        }

        public SortedLinkedList(int value) => head = new ListNode(value);

        public SortedLinkedList(IEnumerable<int> enumerable)
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
            foreach (int element in array)
            {
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
            while (head.Next != null)
            {
                DeleteFirst();
            }
            head = null;
            stopwatch.Stop();
            return (int)stopwatch.ElapsedMilliseconds;
        }

        public void Insert(int value)
        {
            if (head is null || value < head.Value)
            {
                var newHead =  new ListNode(value);
                newHead.Next = head;
                head = newHead;
            }
            else
            {
                var current = head;
                while (current.Next != null && current.Next.Value < value)
                {
                    current = current.Next;
                }

                var tail = current.Next;
                current.Next = new ListNode(value);
                current.Next.Next = tail;
            }
        }

        public void DeleteFirst()
        {
            var current = head;
            head = head.Next;
            current.Next = null;
        }

        public void Print()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }

        public ListNode Search(int value)
        {
            var current = head;
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }

            return current;
        }
    }
}
