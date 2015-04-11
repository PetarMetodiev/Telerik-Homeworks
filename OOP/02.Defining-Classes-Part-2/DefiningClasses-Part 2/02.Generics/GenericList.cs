namespace Generics
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Linq;

    public class GenericList<T> where T : IComparable<T>
    {
        private const uint DefaultInitalCapacity = 16;
        private const uint DefaultInitialCount = 0;
        private const uint DefaulInitialIndex = 0;
        private T[] elements;
        private uint index;
        private uint capacity;
        private uint count;

        public T[] Elements
        {
            get
            {
                return this.elements;
            }
            private set
            {
                this.elements = value;
            }
        }

        private uint Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public uint Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        // Use count for printing the list to limit the elements shown only to those which are entered by the user.
        public uint Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }


        public GenericList()
            : this(DefaultInitalCapacity)
        {
        }

        public GenericList(uint inputCapacity)
        {
            this.Capacity = inputCapacity;
            this.Elements = new T[inputCapacity];
            this.Index = DefaulInitialIndex;
        }

        public T this[uint inputIndex]
        {
            get
            {
                if (inputIndex >= this.Count)
                {
                    throw new IndexOutOfRangeException("No element at the specified index!");
                }
                return this.Elements[inputIndex];
            }
            set
            {
                if (inputIndex >= this.Count)
                {
                    throw new IndexOutOfRangeException("No element at the specified index!");
                }
                this.Elements[inputIndex] = value;
            }
        }

        public void Add(T inputElement)
        {
            this.Elements[this.Index] = inputElement;
            this.Index++;
            this.Count++;

            if (this.Count == this.Elements.Length)
            {
                ExtendAray(this.Elements);
            }
        }

        public T GetElementAtPosition(uint inputPosition)
        {
            if (inputPosition < this.Index)     // Not sure if this check is needed.
            {
                return this.Elements[inputPosition];
            }
            else
            {
                throw new IndexOutOfRangeException("There is no element at the specified position!");
            }
        }

        private void ExtendAray(T[] inputArray)
        {
            T[] tempArray = this.Elements;
            this.Capacity *= 2;
            this.Elements = new T[this.Capacity];
            for (int i = 0; i < tempArray.Length; i++)
            {
                this.Elements[i] = tempArray[i];
            }
        }

        public void RemoveAtPosition(uint inputIndex)
        {
            T[] firstTempArray = new T[this.Count];
            T[] secondTempArray = new T[this.Count];

            if (inputIndex < this.Count)
            {
                for (int i = 0; i < inputIndex; i++)
                {
                    firstTempArray[i] = this.Elements[i];
                }

                for (uint i = inputIndex + 1; i < this.Count; i++)
                {
                    secondTempArray[i] = this.Elements[i];
                }

                this.Elements = new T[this.Capacity];

                for (int i = 0; i < inputIndex; i++)
                {
                    this.Elements[i] = firstTempArray[i];
                }

                for (uint i = inputIndex; i < this.Count - 1; i++)
                {
                    this.Elements[i] = secondTempArray[i + 1];
                }

                this.Count--;
                this.Index--;
            }
            else
            {
                throw new IndexOutOfRangeException("There is no element at the specified position!");
            }


        }

        public void AddElementAtPosition(uint inputIndex, T inputElement)
        {
            this.Count++;
            this.Index++;

            T[] firstTempArray = new T[this.Count];
            T[] secondTempArray = new T[this.Count];

            if (inputIndex < this.Count)
            {
                for (int i = 0; i < inputIndex; i++)
                {
                    firstTempArray[i] = this.Elements[i];
                }

                for (uint i = inputIndex; i < this.Count - 1; i++)
                {
                    secondTempArray[i + 1] = this.Elements[i];
                }

                this.Elements = new T[this.Capacity];


                for (int i = 0; i < inputIndex; i++)
                {
                    this.Elements[i] = firstTempArray[i];
                }

                this.Elements[inputIndex] = inputElement;

                for (uint i = inputIndex + 1; i < this.Count; i++)
                {
                    this.Elements[i] = secondTempArray[i];
                }
            }
            else
            {
                throw new IndexOutOfRangeException("There is no element at the specified position!");
            }
        }

        public void ClearList()
        {
            this.Elements = new T[this.Capacity];
            this.Count = DefaultInitialCount;
            this.Index = DefaulInitialIndex;
        }

        public uint FindIndexOf(T inputElement)
        {
            for (uint i = 0; i < this.Count; i++)
            {
                if (this.Elements[i].CompareTo(inputElement)==0)
                {
                    return i;
                }
            }

            throw new ArgumentOutOfRangeException("There is no such element!");        // I don't know if I should trow an exception or return some value.
        }

        public T Max()
        {
            T maxValue = this.Elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (maxValue.CompareTo(this.Elements[i]) < 0)
                {
                    maxValue = this.Elements[i];
                }
            }
            return maxValue;
        }

        public T Min()
        {
            T minValue = this.Elements[0];
            for (int i = 1; i < this.Count; i++)
            {
                if (minValue.CompareTo(this.Elements[i])>0)
                {
                    minValue = this.Elements[i];
                }
            }
            return minValue;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                output.Append(string.Format("{0}", this.Elements[i].ToString()));
                if (i != this.Count - 1)
                {
                    output.AppendLine();
                }
            }
            return output.ToString();
        }
    }
}
