using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    /// <summary>
    /// queue data structure of elements of any type
    /// </summary>
    /// <typeparam name="T">queue element type</typeparam>
    public class QueueLib<T> : IEnumerable<T>
    {
        /// <summary>
        /// start queue capacity
        /// </summary>
        private const uint StartCapacity = 10;
        /// <summary>
        /// inner array
        /// </summary>
        private T[] array;

        private int start;
        private int end;

        private int count;
        /// <summary>
        /// queue "version"
        /// </summary>
        private int version;
        /// <summary>
        /// creates queue with specified start capacity
        /// </summary>
        /// <param name="capacity"></param>
        public QueueLib(uint capacity = StartCapacity)
        {
            array = new T[capacity];
        }

        public int Count => count;

        public void Enqueue(T item)
        {
            if (count == array.Length)
            {
                var newArray = new T[array.Length * 2];
                if (count > 0)
                {
                    if (start < end)
                    {
                        Array.Copy(array, start, newArray, 0, array.Length - start);
                        Array.Copy(array, 0, newArray, array.Length - start, end);
                    }
                }

                array = newArray;
                start = 0;
                end = count;
            }

            array[end] = item;
            end = (end + 1) % array.Length;
            count++;
            version++;
        }
        /// <summary>
        /// removes first queue element and returns it's value
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("the queue is empty");
            }

            var item = array[start];
            start = (start + 1) % array.Length;
            count--;
            version++;

            return item;
        }
        /// <summary>
        /// returns first queue element
        /// </summary>
        /// <returns>first queue element</returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("the queue is empty");
            }

            return array[start];
        }
        /// <summary>
        /// clear the queue
        /// </summary>
        public void Clear()
        {
            if (start < end)
            {
                Array.Clear(array, start, array.Length - start);
                Array.Clear(array, 0, end);
            }

            start = 0;
            end = 0;
            count = 0;
            version++;
        }
        /// <summary>
        /// gets queue enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// queue to enumerate
            /// </summary>
            private QueueLib<T> queue;
            /// <summary>
            /// current index
            /// </summary>
            private int index;
            /// <summary>
            /// current value
            /// </summary>
            public T current;
            /// <summary>
            /// current version
            /// </summary>
            private int version;
            /// <summary>
            /// constructs enumerator of specified queue
            /// </summary>
            /// <param name="queue">queue to enumerate</param>
            public QueueEnumerator(QueueLib<T> queue)
            {
                this.queue = queue;
                index = -1;
                current = default(T);
                version = queue.version;
            }
            public T Current
            {
                get
                {
                    if (index >= 0)
                    {
                        return current;
                    }
                    else
                    {
                        throw new InvalidOperationException(index == -1 ? "enumerator is before start" : "enumerator is after end");
                    }
                }
            }
            /// <summary>
            /// get current object
            /// </summary>
            object IEnumerator.Current => Current;
            /// <summary>
            /// disposes resources
            /// </summary>
            public void Dispose()
            {

            }
            /// <summary>
            /// moves enumerator to the next element
            /// </summary>
            /// <returns>true if success; otherwise false</returns>
            public bool MoveNext()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException("queue was changed");
                }
                if (index == -2)
                {
                    return false;
                }
                if (++index == queue.count)
                {
                    index = -2;
                    current = default(T);
                    return false;
                }

                current = queue.array[(queue.start + index) % queue.array.Length];
                return true;
            }
            /// <summary>
            /// resets enumerator position
            /// </summary>
            public void Reset()
            {
                if (version != queue.version)
                {
                    throw new InvalidOperationException("queue was changed");
                }

                index = -1;
                current = default(T);
            }
        }
        /// <summary>
        /// returns enumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
