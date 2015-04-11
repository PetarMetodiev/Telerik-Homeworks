namespace ExtensionTasks
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using ExtensionTasks.Extensions;

    class ExtensionsTest
    {

        public static void Main()
        {
            string myString = "Kak da ti kaja kolko e kazvano za kazvaneto!";
            StringBuilder myStringBuilder = new StringBuilder();
            myStringBuilder.Append("Kak da ti kaja kolko e kazvano za kazvaneto!");

            Console.WriteLine(myString.Substring(3,5));
            Console.WriteLine(myStringBuilder.Substring(5));
            Console.WriteLine(myStringBuilder.Substring(3,5));

            var myList = new List<decimal>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(1);
            myList.Add(2);
            myList.Add(1);
            myList.Add(1);

            Console.WriteLine(myList.Average());
        }
    }
}
