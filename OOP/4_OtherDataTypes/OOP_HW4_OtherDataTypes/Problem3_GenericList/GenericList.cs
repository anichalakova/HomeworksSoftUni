using System;

namespace Problem3_GenericList
{
    [Version ("1:1")]

    public class GenericList<T> where T : IComparable<T>
    {
        public const int DefaultCapacity = 16;

        private T[] elements = null;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            if (count >= elements.Length)
            {
                T[] doubleElements = new T[elements.Length * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    doubleElements[i] = elements[i];
                }

                elements = doubleElements;
            }

            this.elements[count] = element;
            this.count++;
        }

        public T Get(int index)
        {
            try
            {
                return this.elements[index];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of range!");
                return default(T);
            }
        }

        public void Remove(int index)
        {
            try
            {
                this.elements[index] = default(T);
                this.count--;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of range!");
            }
        }

        public void Insert(int index, T value)
        {
            try
            {
                this.elements[index] = value;
                this.count++;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of range!");
            }
        }

        public void Clear()
        {
            for (int i = 0; i < this.count; i++)
            {
                this.elements[i] = default(T);
            }
        }

        public int SearchValue(T value)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            return String.Join(", ", this.elements);
        }

        public T Min()
        {
            T min = this.elements[0];
            for (int i = 1; i < this.elements.Length; i++)
            {
                if (min.CompareTo(this.elements[i]) < 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = this.elements[0];
            for (int i = 1; i < this.elements.Length; i++)
            {
                if (max.CompareTo(this.elements[i]) > 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
    }
}