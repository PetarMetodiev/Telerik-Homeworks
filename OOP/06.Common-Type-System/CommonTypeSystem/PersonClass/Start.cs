namespace PersonClass
{
    using System;
    class Start
    {
        static void Main()
        {
            var firstPirson = new Person();

            firstPirson.Name = "Georgi";
            firstPirson.Age = 18;

            var secondPerson = new Person();

            secondPerson.Name = "Ivan";

            Console.WriteLine(firstPirson);
            Console.WriteLine(secondPerson);
        }
    }
}
