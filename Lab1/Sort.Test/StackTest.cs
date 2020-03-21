using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Sort.Test
{
    class Test
    {

        [Test]
        public void StackTestEmpty()
        {
            var s = new Stack(3);
            var p = new Pair(1, 1);

            s.Push(p);
            s.Push(p);
            s.Push(p);

            s.Pop();
            s.Pop();
            s.Pop();

            Assert.AreEqual(true, s.IsEmpty());
        }

        [Test]
        public void StackTestException()
        {
            var s = new Stack(3);
            var p = new Pair(1, 1);

            s.Push(p);
            s.Push(p);
            s.Push(p);

            s.Pop();
            s.Pop();
            s.Pop();

        }
    }
}
