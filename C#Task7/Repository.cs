using System;
using System.Collections.Generic;
using System.Text;

namespace C_Task7
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        T[] arr;
        private int capacity;
        public Repository(int capacity = 10)
        {
            this.capacity = capacity;
            arr = new T[capacity];
            Count = 0;
        }
        public int Count { set; get; }

        public void Add(T item)
        {
            if(Count == capacity)
            {
                capacity *= 2;
                T[] new_arr = new T[capacity];
                Array.Copy(arr, new_arr, Count);
                arr = new_arr;
            }

            arr[Count++] = item;
        }
        public bool Remove(T item)
        {
            int indx = -1;
            for (int i = 0; i < Count; i++) {
                if (EqualityComparer<T>.Default.Equals(item, arr[i]))
                {
                   indx = i; break;
                }
            }
            if(indx < 0 ) return false;
            for(int i = indx; i< Count-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Count--;
            return true;
        }
        public void Sort()
        {
            Array.Sort(arr,0,Count);
        }
        public T[] GetAll()
        {
            T[] result = new T[Count];
            Array.Copy(arr, result, Count);
            return result;
        }

    }
}
