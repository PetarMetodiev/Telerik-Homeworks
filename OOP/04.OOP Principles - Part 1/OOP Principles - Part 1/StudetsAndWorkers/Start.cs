namespace StudetsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Start
    {
        static void Main()
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Ivan","Petkov", 3),
                new Student("Stoian","Atanasov", 6),
                new Student("Georgi","Barzakov", 5),
                new Student("Boiko","Borisov", 4),
                new Student("Georgi","Glavunin", 2),
                new Student("Stanislav","Bakalov", 4),
                new Student("Kiril","Kojuharov", 6),
                new Student("Josif","Kalkandjiev", 6),
                new Student("Atanas","Nikolov", 2),
                new Student("Cvetan","Georgiev", 6),
            };

            var sortedStudents = studentList
                .OrderBy(st => st.Grade)
                .ToList();

            //foreach (var student in sortedStudents)
            //{
            //    Console.WriteLine(student);
            //}

            List<Worker> workerList = new List<Worker>
            {
                new Worker("Petar", "Ivanov", 550.50M, 8),
                new Worker("Cvetan", "Cvetan", 330M, 6),
                new Worker("Stanislav", "Georgiev", 1265.20M, 12),
                new Worker("Ivan", "Kojuharov", 256.36M, 4),
                new Worker("Josif", "Barzakov", 1836.23M, 15),
                new Worker("Stoian", "Borisov", 496.78M, 7),
                new Worker("Atanas", "Bakalov", 669.32M, 9),
                new Worker("Boiko", "Glavunin", 3256.78M, 8),
                new Worker("Georgi", "Petkov", 782.39M, 10),
                new Worker("Kiril", "Borisov", 667.54M, 8)
            };

            var sortedWorkers = workerList
                .OrderByDescending(w => w.MoneyPerHour())
                .ToList();

            //foreach (var worker in sortedWorkers)
            //{
            //    Console.WriteLine(worker);
            //}

            List<Human> merged = new List<Human>();

            for (int i = 0; i < sortedStudents.Count; i++)
            {
                merged.Add(sortedStudents[i]);
            }

            for (int i = 0; i < sortedWorkers.Count; i++)
            {
                merged.Add(sortedWorkers[i]);
            }

            var mergedSorted = merged
                .OrderBy(m => m.FirstName)
                .ThenBy(m => m.LastName)
                .ToList();

            foreach (var human in mergedSorted)
            {
                Console.WriteLine(human);
            }
        }
    }
}
