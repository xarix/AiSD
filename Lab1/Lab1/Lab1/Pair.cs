using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class Pair
    {
        public Pair(int x, int y)
        {
            left = x;
            right = y;
        }
        public int left { get; set; }
        public int right { get; set; }
    }
}
