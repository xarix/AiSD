using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class Stack
    {
        private readonly Pair[] stack;
        private readonly int max;
        private int elements;

        public Stack(int size)
        {
            stack = new Pair[size];
            max = size;
        }

        public void Push(Pair n)
        {
            if (elements < max)
            {
                stack[elements++] = n;
            }
        }

        public Pair Pop()
        {
            if (!IsEmpty())
            {
                return stack[--elements];
            }

            throw new InvalidOperationException("Stack is empty!");
        }

        public bool IsEmpty() => elements == 0;
    }
}
