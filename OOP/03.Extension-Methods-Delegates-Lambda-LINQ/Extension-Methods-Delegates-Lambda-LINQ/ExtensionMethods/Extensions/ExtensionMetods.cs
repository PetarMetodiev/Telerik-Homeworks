namespace ExtensionTasks.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public static class ExtensionMetods
    {
        public static StringBuilder Substring(this StringBuilder strb, int startIndex)
        {
            StringBuilder substring = new StringBuilder();
            CheckInput(strb, startIndex, strb.Length);
            for (int i = startIndex; i < strb.Length; i++)
            {
                substring.Append(strb[i]);
            }
            return substring;
        }

        public static StringBuilder Substring(this StringBuilder strb, int startIndex, int length)
        {
            StringBuilder substring = new StringBuilder();
            CheckInput(strb, startIndex, length);
            for (int i = startIndex; i < startIndex + length; i++)
            {
                substring.Append(strb[i]);
            }
            return substring;
        }

        private static void CheckInput(StringBuilder strb, int inputStartIndex, int inputEndIndex)
        {
            if (inputStartIndex < 0)
            {
                throw new IndexOutOfRangeException("The index has to be positive!");
            }
            else if (inputStartIndex > strb.Length)
            {
                throw new IndexOutOfRangeException("The specified index is outside the length of the string!");
            }

            if (inputStartIndex > inputEndIndex)
            {
                throw new IndexOutOfRangeException();
            }
            else if (inputEndIndex > strb.Length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static T Sum<T>(this IEnumerable<T> collection)
            where T : struct
        {
            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
            where T : struct
        {
            dynamic product = 1;
            foreach (var item in collection)
            {
                product *= item;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : struct, IComparable
        {
            T minValue = collection.First();

            foreach (var item in collection)
            {
                if (item.CompareTo(minValue) < 0)
                {
                    minValue = item;
                }
            }
            return minValue;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : struct, IComparable
        {
            T maxValue = collection.First();

            foreach (var item in collection)
            {
                if (item.CompareTo(maxValue) > 0)
                {
                    maxValue = item;
                }
            }
            return maxValue;
        }

        public static T Average<T>(this IEnumerable<T> collection)
            where T : struct, IComparable
        {
            int count = collection.ToList().Count;
            dynamic average = (dynamic)collection.Sum() / count;
            return average;
        }
    }
}
