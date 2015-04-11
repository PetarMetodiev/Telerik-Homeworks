namespace LINQ
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public StringBuilder PrintMarks()
        {
            StringBuilder marksAsString = new StringBuilder();
            foreach (var mark in this.Marks)
            {
                marksAsString.Append(mark);
                marksAsString.Append(" ");
            }

            return marksAsString;
        }
    }
}
