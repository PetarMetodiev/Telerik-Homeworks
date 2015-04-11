namespace Generics
{
    using System;

    class GenericsMain
    {
        static void Main()
        {
            var myList = new GenericList<int>(3);

            myList.Add(8);
            myList.Add(1);
            myList.Add(2);
            myList.Add(5);
            myList.Add(1);
            myList.Add(6);
            myList.Add(8);

            myList.RemoveAtPosition(2);
            myList.AddElementAtPosition(2, 18);
            Console.WriteLine(myList[2]);
            Console.WriteLine();
            Console.WriteLine(myList);
        }
    }
}
