namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class SchoolStart
    {
        static void Main()
        {
            // I wanted to use a class library and only create a school, without creating new instances of the students, teachers and disciplines, but couldn't figure it out. Also I wanted to make the classes internal up to school, but couldn't do that as well.

            List<Student> newStudents = new List<Student>();

            newStudents.Add(new Student("Georgi", "Radnev", 12, "Very lazy"));
            newStudents.Add(new Student("Ivan", "Georgiev", 11, "Smart"));
            newStudents.Add(new Student("Stanimir", "Ivanov", 1, "Very smart"));
            newStudents.Add(new Student("Petyr", "Dynov", 2));
            newStudents.Add(new Student("Petyr", "Andonov", 23, "Inobedient"));
            newStudents.Add(new Student("Boryana", "Gamzakova", 5));
            newStudents.Add(new Student("Maria", "Boneva", 8, "Playful"));
            newStudents.Add(new Student("Pavel", "Kormev", 6, "Smart"));
            newStudents.Add(new Student("Gergana", "Goneva", 7, "Artistic"));
            newStudents.Add(new Student("Teodor", "Manolov", 4, "Likes math"));
            newStudents.Add(new Student("Aleksandyr", "Viktorov", 17));
            newStudents.Add(new Student("Ilarion", "Mavrudiev", 9, "Religious"));

            List<Discipline> naturalSciences = new List<Discipline>();

            naturalSciences.Add(new Discipline("Math", 15, 15));
            naturalSciences.Add(new Discipline("Physics", 20, 20));
            naturalSciences.Add(new Discipline("Chemistry", 10, 20));
            naturalSciences.Add(new Discipline("Biology", 5, 5));

            List<Discipline> humanSciences = new List<Discipline>();

            humanSciences.Add(new Discipline("English language", 15, 15));
            humanSciences.Add(new Discipline("History", 10, 15));
            humanSciences.Add(new Discipline("Literature", 12, 12));
            humanSciences.Add(new Discipline("Religion", 2, 2));

            List<Discipline> arts = new List<Discipline>();

            arts.Add(new Discipline("Music", 7, 7));
            arts.Add(new Discipline("Fine arts", 6, 6));
            arts.Add(new Discipline("Dancing", 10, 10));
            arts.Add(new Discipline("Graphical design", 13, 13));

            List<Teacher> newTeachers = new List<Teacher>();

            newTeachers.Add(new Teacher("Bano", "Banov", naturalSciences));
            newTeachers.Add(new Teacher("Georgi", "Vylkanov", naturalSciences));
            newTeachers.Add(new Teacher("Stoian", "Ivanov", naturalSciences));

            newTeachers.Add(new Teacher("Evlogi", "Georgiev", humanSciences));
            newTeachers.Add(new Teacher("Ivaylo", "Bostanov", humanSciences));
            newTeachers.Add(new Teacher("Erhip", "Hantov", humanSciences));

            newTeachers.Add(new Teacher("Giorgos", "Mazonakis", arts));
            newTeachers.Add(new Teacher("Maria", "Ilieva", arts));
            newTeachers.Add(new Teacher("Slavi", "Trifonov", arts));

            School newSchool = new School("PMG Nikola Obreshkov");


            newSchool.AddSchoolClass("Cherrypie");

            newSchool.AddCommentsToClass("Cherrypie", "Happy students");

            newSchool.AddStudentToClass("Cherrypie", newStudents[0]);
            newSchool.AddStudentToClass("Cherrypie", newStudents[1]);
            newSchool.AddStudentToClass("Cherrypie", newStudents[2]);
            newSchool.AddStudentToClass("Cherrypie", newStudents[3]);

            newSchool.AddTeacherToClass("Cherrypie", newTeachers[0]);
            newSchool.AddTeacherToClass("Cherrypie", newTeachers[3]);
            newSchool.AddTeacherToClass("Cherrypie", newTeachers[6]);


            newSchool.AddSchoolClass("Doomed");

            newSchool.AddCommentsToClass("Doomed", "Somewhat depressed students");

            newSchool.AddStudentToClass("Doomed", newStudents[4]);
            newSchool.AddStudentToClass("Doomed", newStudents[5]);
            newSchool.AddStudentToClass("Doomed", newStudents[6]);
            newSchool.AddStudentToClass("Doomed", newStudents[7]);

            newSchool.AddTeacherToClass("Doomed", newTeachers[1]);
            newSchool.AddTeacherToClass("Doomed", newTeachers[4]);
            newSchool.AddTeacherToClass("Doomed", newTeachers[7]);


            newSchool.AddSchoolClass("Marshmallow");

            newSchool.AddCommentsToClass("Marshmallow", "Little sweeties");

            newSchool.AddStudentToClass("Marshmallow", newStudents[8]);
            newSchool.AddStudentToClass("Marshmallow", newStudents[9]);
            newSchool.AddStudentToClass("Marshmallow", newStudents[10]);
            newSchool.AddStudentToClass("Marshmallow", newStudents[11]);

            newSchool.AddTeacherToClass("Marshmallow", newTeachers[2]);
            newSchool.AddTeacherToClass("Marshmallow", newTeachers[5]);
            newSchool.AddTeacherToClass("Marshmallow", newTeachers[8]);

            Console.WriteLine(newSchool);
        }
    }
}
