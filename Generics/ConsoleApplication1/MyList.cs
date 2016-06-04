using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyList<T>
    {
        T[] elements = null;

        public MyList()
        {
            elements = new T[4];
            Capacity = 4;
        }

        public int Count { get; private set; } = 0;

        public int Capacity { get; private set; }

        public void Add(T value)
        {
            if (Count == Capacity)
            {
                ReSize();
            }
            elements[Count] = value;
            Count++;
        }

        private void ReSize()
        {
            var tempArr = new T[elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                tempArr[i] = elements[i];
            }
            elements = tempArr;
            Capacity = tempArr.Length;
        }

        public T this[int index]
        {
            get { return elements[index]; }
            set
            {
                elements[index] = value;
            }
        }

        public void Clear()
        {
            elements = new T[0];
        }

        public bool Contains(T value, out int index)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Equals(value))
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        public void Remove()
        {
            var tempArr = new T[elements.Length - 1];
            Array.ConstrainedCopy(elements, 0, tempArr, 0, tempArr.Length);
            elements = tempArr;
            Count--;
        }
        public bool Remove(T value)
        {
            //bool fl = false;
            //int j = 0;
            //for (int i = 0; i < elements.Length; i++)
            //{
            //    if (this[i].Equals(value))
            //    {

            //        fl = true;
            //        continue;
            //    }
            //    this[j] = elements[i];
            //    j++;
            //}
            //return fl;

            int index;
            if (Contains(value, out index))
            {
                var tempArr = new T[elements.Length - 1];
                Array.ConstrainedCopy(elements, 0, tempArr, 0, index);
                Array.ConstrainedCopy(elements, index + 1, tempArr, index, tempArr.Length - index);
                elements = tempArr;
                Count--;
                return true;
            }
            return false;
        }



        public IEnumerator<T> GetEnumerator()
        {
            int position = -1;
            while (true)
            {
                if (position < Count - 1)
                {
                    position++;
                    yield return elements[position];

                }
                else
                {
                    yield break;
                }
            }
        }
    }
}
