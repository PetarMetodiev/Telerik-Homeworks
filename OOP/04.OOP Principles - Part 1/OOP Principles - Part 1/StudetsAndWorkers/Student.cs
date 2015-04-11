namespace StudetsAndWorkers
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private int grade;

        public Student(string inputFirstName, string inputLastName, int inputGrade)
            : base(inputFirstName, inputLastName)
        {
            this.Grade = inputGrade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Invalid grade!");
                }
                this.grade = value;
            }
        }

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();
            studentInfo.Append("Name: " + this.FirstName + " " + this.LastName);
            studentInfo.AppendLine();
            studentInfo.Append("Grade: " + this.Grade);
            studentInfo.AppendLine();
            return studentInfo.ToString();
        }
    }
}
