namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    class Start
    {
        static void Main()
        {
            Animal myDog = new Dog(12, "Johny", Sex.Male);
            Console.WriteLine(myDog.ProduceSound());

            Animal myTomCat = new Tomcat(11, "Myrzel");
            Console.WriteLine(myTomCat.ProduceSound());

            Animal myKitten = new Kitten(5, "Ligla");
            Console.WriteLine(myKitten.ProduceSound());

            Animal myFrog = new Frog(21, "Jabcho", Sex.Male);
            Console.WriteLine(myFrog.ProduceSound());

            Console.WriteLine();
            Console.WriteLine();

            var frogArray = new Frog[]
            {
                new Frog(2,"Kozel",Sex.Male),
                new Frog(1,"Myrlio",Sex.Male),
                new Frog(5,"Patka",Sex.Female),
                new Frog(3,"Balkan",Sex.Male),
                new Frog(22,"Ivan",Sex.Male),
            };

            Console.WriteLine("Average frog age: " + Animal.AverageAge(frogArray));

            var dogArray = new Dog[]
            {
                new Dog(12,"Vihyr",Sex.Male),
                new Dog(15,"Vylkodav",Sex.Male),
                new Dog(5,"Vragomorka",Sex.Female),
                new Dog(21,"Izdryjlivko",Sex.Male)
            };

            Console.WriteLine("Average dog age: " + Animal.AverageAge(dogArray));

            var kittenArray = new Kitten[]
            {
                new Kitten(2,"Ligla"),
                new Kitten(12,"Kosmatka")
            };

            Console.WriteLine("Average kitten age: " + Animal.AverageAge(kittenArray));

            var tomCatArray = new Tomcat[]
            {
                new Tomcat(15,"Mirizlivko"),
                new Tomcat(21,"Mustakatko"),
                new Tomcat(2,"Liubopitko")
            };

            Console.WriteLine("Average tomcat age: " + Animal.AverageAge(tomCatArray));
        }
    }
}
