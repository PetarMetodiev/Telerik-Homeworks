namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private Sex sex;

        public Animal(int inputAge, string inputName)
        {
            this.Age = inputAge;
            this.Name = inputName;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Invalid age!");
                }
                this.age = value;
            }
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }
            protected set
            {
                this.sex = value;
            }
        }

        public static double AverageAge(Animal[] animalArray)
        {
            var averageAnimalAge = animalArray.Average(a => a.Age);
            return Math.Round(averageAnimalAge,2);
        }

        public abstract string ProduceSound();
    }
}
