namespace StudentClass
{
    using System;
    
    public class Start
    {
        static void Main()
        {

            var firstStudent = new Student("Georgi", "Georgiev", "Georgiev", 666589745, "ul. Goliama Gora v Grada 7", "0887755666", "alabala@abv.bg", 2, Specialty.Architecture, University.UACEG, Faculty.ArchitectureFaculty);

            var secondStudent = new Student("Georgi", "Georgiev", "Georgiev", 666589745, "ul. Goliama Gora v Grada 7", "0887755666", "alabala@abv.bg", 2, Specialty.Architecture, University.UACEG, Faculty.ArchitectureFaculty);

            var thirdStudent = new Student("Georgi", "Georgiev", "Georgiev", 111111111, "ul. Goliama Gora v Grada 7", "0887755666", "alabala@abv.bg", 2, Specialty.Architecture, University.UACEG, Faculty.ArchitectureFaculty);

            var fourthStudent = new Student("Georgi", "Georgiev", "Georgiev", 1111111110, "ul. Goliama Gora v Grada 7", "0887755666", "alabala@abv.bg", 2, Specialty.Architecture, University.UACEG, Faculty.ArchitectureFaculty);


            var cloneStudent = (Student)firstStudent.Clone();

            Console.WriteLine(firstStudent);
            Console.WriteLine();
            Console.WriteLine(cloneStudent);
            Console.WriteLine(thirdStudent.CompareTo(fourthStudent));
        }
    }
}
