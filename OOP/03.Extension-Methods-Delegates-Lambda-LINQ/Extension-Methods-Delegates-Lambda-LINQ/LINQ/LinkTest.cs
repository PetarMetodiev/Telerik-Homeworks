namespace LINQ
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class LinkTest
    {
        // Not the best implemetation, just for my ulesnenie.
        public static void PrintStudents(List<Student> students, bool printAdditional = false)
        {
            if (!printAdditional)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine("First name: " + student.FirstName);
                    Console.WriteLine("Last name: " + student.LastName);
                    Console.WriteLine("Email: " + student.Email);
                    Console.WriteLine("FN: " + student.FN);
                    Console.WriteLine("Marks: " + student.PrintMarks());
                    Console.WriteLine("Phone number: " + student.Tel);
                    Console.WriteLine("Group: " + student.GroupNumber);
                    Console.WriteLine();
                }
            }

        }
        static void Main()
        {
            // Also possible with anonymos type.
            var studentCollection = new List<Student>();
            studentCollection.Add(new Student()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Age = 16,
                FN = "123406",
                Tel = "02123456789",
                Email = "alabala@gmail.com",
                Marks = new List<int>() { 2, 3, 6, 5, 3, 6, 6 },
                GroupNumber = 2
            });

            studentCollection.Add(new Student()
            {
                FirstName = "Grigor",
                LastName = "Ivanov",
                Age = 18,
                FN = "122206",
                Tel = "02123555789",
                Email = "alabala@abv.com",
                Marks = new List<int>() { 2, 4, 2, 3, 3, 2, 2 },
                GroupNumber = 2
            });
            studentCollection.Add(new Student()
            {
                FirstName = "Bastun",
                LastName = "Malinov",
                Age = 21,
                FN = "323407",
                Tel = "0567778998",
                Email = "portokal@gmail.com",
                Marks = new List<int>() { 2, 3, 6 },
                GroupNumber = 5
            });
            studentCollection.Add(new Student()
            {
                FirstName = "Grigor",
                LastName = "Goranov",
                Age = 25,
                FN = "523400",
                Tel = "08877665544",
                Email = "krastavica@abv.bg",
                Marks = new List<int>() { 3, 6, 6 },
                GroupNumber = 3
            });
            studentCollection.Add(new Student()
            {
                FirstName = "Igor",
                LastName = "Malinov",
                Age = 24,
                FN = "123206",
                Tel = "03369887",
                Email = "gospodin@hotmail.com",
                Marks = new List<int>() { 2, 2, 6, 6 },
                GroupNumber = 5
            });
            studentCollection.Add(new Student()
            {
                FirstName = "Pesho",
                LastName = "Stavriev",
                Age = 2,
                FN = "444401",
                Tel = "unknown",
                Email = "glavatar@abv.bg",
                Marks = new List<int>() { 3, 6, 5, 3 },
                GroupNumber = 1
            });

            // Problem 3
            Console.WriteLine("Problem 3: ");

            var selectedStudents = studentCollection.Where(st => st.FirstName.CompareTo(st.LastName) < 0).ToList();

            PrintStudents(selectedStudents);

            Console.WriteLine(new string('-', 20));

            // Problem 4
            Console.WriteLine("Problem 4: ");
            var studentAtAnAge = studentCollection.Where(st => st.Age >= 18 && st.Age <= 24).ToList();

            PrintStudents(studentAtAnAge);

            Console.WriteLine(new string('-', 20));

            //Problem 5
            Console.WriteLine("Problem 5: ");

            var sortedStudentsByName = studentCollection.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName).ToList();

            PrintStudents(sortedStudentsByName);

            Console.WriteLine(new string('-', 20));

            // Problem 6
            Console.WriteLine("Problem 6: ");

            var arrayOfIntegers = new int[]
            {
                504,7,8,1,99,63,76,6546,44,57,223,77,-9,0,21,47,42
            };

            var divisible = arrayOfIntegers.Where(x => (x % 7 == 0) && (x % 3 == 0))/*.OrderBy(x => x)*/;

            foreach (var integer in divisible)
            {
                Console.WriteLine(integer);
            }

            Console.WriteLine(new string('-', 20));

            // Problem 9. I can't find the difference between Problem 9 and 10. Aren't .Where() .OrderBy() etc. extension methods?
            Console.WriteLine("Problem 9: ");

            var studentsFromGroupTwo = studentCollection.Where(st => st.GroupNumber == 2).OrderBy(st => st.FirstName).ToList();

            PrintStudents(studentsFromGroupTwo, true);

            Console.WriteLine(new string('-', 20));

            // Problem 11
            Console.WriteLine("Problem 11: ");

            var studentsByEmail = studentCollection.Where(st => st.Email.Contains("@abv.bg")).ToList();

            PrintStudents(studentsByEmail, true);

            Console.WriteLine(new string('-', 20));

            // Problem 12
            Console.WriteLine("Problem 12: ");

            var studentsFromSofia = studentCollection.Where(st => st.Tel.StartsWith("02")).ToList();

            PrintStudents(studentsFromSofia, true);

            Console.WriteLine(new string('-', 20));

            // Problem 13
            Console.WriteLine("Problem 13: ");

            var annonymousStudents = from student in studentCollection
                                     where student.Marks.Contains(6)
                                     select new
                                     {
                                         FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                                         Marks = student.Marks,

                                     };

            foreach (var student in annonymousStudents)
            {
                Console.WriteLine("Full name: " + student.FullName);
                foreach (var mark in student.Marks)
                {
                    Console.WriteLine("Mark: " + mark);
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 20));

            // Problem 14
            Console.WriteLine("Problem 14: ");

            var tapaci = studentCollection
                .Where(st => st.Marks.Count(m => m == 2) == 2)
                .ToList();
            PrintStudents(tapaci, true);

            Console.WriteLine(new string('-', 20));

            //Problem 15
            Console.WriteLine("Problem 15: ");

            var enrolledStudents = studentCollection.Where(st => st.FN.Substring(4, 2) == "06").ToList();

            PrintStudents(enrolledStudents, true);

            Console.WriteLine(new string('-', 20));

            // Problem 17
            Console.WriteLine("Problem 17: ");

            var arrayOfStrings = new string[]
            {
                "a", "aa", "aaaaaa", "aaa", "aaaaaaaaaaa", "aaaa", "aaaaaaaaaaaaaaaaa"
            };

            var sortedStrings = arrayOfStrings.OrderByDescending(st => st.Length).First();

            Console.WriteLine(sortedStrings);

            Console.WriteLine(new string('-', 20));

            // Problem 18. Again cant find the difference between problem 18 and 19. I suppose that it is required to do it without the extension methods but at the lecture we were told that this is an old method of using LINQ and it is better to get used to using the extension methods.

            Console.WriteLine("Problem 18: ");

            var groupByGroupNumber =
                studentCollection
                .GroupBy(st => st.GroupNumber)
                .OrderBy(gr => gr.Key)
                .ToList();

            foreach (var group in groupByGroupNumber)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student.FirstName);
                    Console.WriteLine(student.LastName);
                    Console.WriteLine(student.GroupNumber);
                    Console.WriteLine();
                }
            }
        }
    }
}
