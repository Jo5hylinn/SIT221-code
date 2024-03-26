using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity { get; private set; } = 0;

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[data.Length + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == data.Length) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        // TODO:********************************************************************************************

        public void Insert(int index, T element)
        {
            // If index is outside the range of the current Vector, throw an IndexOutOfRangeException
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            // If Count already equals Capacity, increase the capacity of the Vector<T> by reallocating the internal array
            if (Count == Capacity)
            {
                ExtendData(DEFAULT_CAPACITY);
            }

            // If index is equal to Count, add the item to the end of the Vector<T>
            if (index == Count)
            {
                data[Count++] = element;
            }
            else
            {
                // Shift elements to make room for the new item
                for (int i = Count; i > index; i--)
                {
                    data[i] = data[i - 1];
                }

                // Place the new item at the specified index
                data[index] = element;
                Count++;
            }
        }

        public void Clear()
        {
            // Remove all elements by setting Count back to 0
            Count = 0;
        }

        public bool Contains(T element)
        {
            // Use IndexOf method to determine if the item is already in the data collection
            return IndexOf(element) != -1;
        }

        public bool Remove(T element)
        {
            // Find the index of the item using IndexOf method
            int index = IndexOf(element);

            // If the item is not found, return false
            if (index == -1)
            {
                return false;
            }

            // Remove the item at the found index using RemoveAt method
            RemoveAt(index);

            // Return true to indicate that the removal was successful
            return true;
        }

        public void RemoveAt(int index)
        {
            // If the index is invalid (out of range), throw an IndexOutOfRangeException
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }

            // Shift elements to the left to overwrite the element at the specified index
            for (int i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            // Decrement the count of elements to reflect the removal
            Count--;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("["); // Start with opening square bracket

            // Append each element to the string, separated by commas
            for (int i = 0; i < Count; i++)
            {
                sb.Append(data[i]);
                if (i < Count - 1)
                {
                    sb.Append(", "); // Add comma if not the last element
                }
            }

            sb.Append("]"); // End with closing square bracket
            return sb.ToString();
        }

    }
}
