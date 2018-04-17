using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    [TestFixture]
    public class QueueLibTests
    {
        private const uint CapacityTest = 5;
        private static QueueLib<int> queue = new QueueLib<int>(CapacityTest);

        [Test]
        public void QueueTest()
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
            for (int i = 0; i < CapacityTest; i++)
            {
                queue.Enqueue(i + 1);
            }

            Assert.AreEqual(1, queue.Peek());
            for (int i = 0; i < CapacityTest; i++)
            {
                Assert.AreEqual(i + 1, queue.Dequeue());
            }

            Assert.Throws<InvalidOperationException>(() => queue.Peek());

            var enumerator = queue.GetEnumerator();
            int current;
            Assert.Throws<InvalidOperationException>(() => { current = enumerator.Current; });
            Assert.False(enumerator.MoveNext());
            Assert.DoesNotThrow(() => enumerator.Reset());

            queue.Enqueue(10);
            Assert.Throws<InvalidOperationException>(() => enumerator.Reset());
            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());

            enumerator = queue.GetEnumerator();
            Assert.Throws<InvalidOperationException>(() => { current = enumerator.Current; });
            Assert.True(enumerator.MoveNext());
            Assert.AreEqual(10, enumerator.Current);
            Assert.False(enumerator.MoveNext());

            Assert.DoesNotThrow(() => enumerator.Reset());
            Assert.Throws<InvalidOperationException>(() => { current = enumerator.Current; });
            Assert.True(enumerator.MoveNext());
            Assert.AreEqual(10, enumerator.Current);
            Assert.False(enumerator.MoveNext());

            Assert.AreEqual(10, queue.Dequeue());
        }
    }
}
