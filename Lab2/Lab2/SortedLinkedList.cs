using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class SortedLinkedList
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

        public void Insert(int value)
        {
            if (head is null || value < head.value)
            {
                var newHead =  new ListNode(value);
                newHead.next = head;
                head = newHead;
            }
            else
            {
                var current = head;
                while (current.next != null && current.next.value < value)
                {
                    current = current.next;
                }

                var tail = current.next;
                current.next = new ListNode(value);
                current.next.next = tail;
            }
        }

        public void DeleteFirst()
        {
            var current = head;
            head = head.next;
            current.next = null;
        }

        public void Print()
        {
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public ListNode Search(int value)
        {
            var current = head;
            while (current != null && current.value != value)
            {
                current = current.next;
            }

            return current;
        }
    }
}
