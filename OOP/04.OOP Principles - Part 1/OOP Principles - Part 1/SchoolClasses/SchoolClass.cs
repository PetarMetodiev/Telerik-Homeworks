namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SchoolClass : ICommentable
    {
        private string uti; // Unique Text Identifier
        private List<Teacher> setOfTeachers = new List<Teacher>();
        private List<Student> setOfStudents = new List<Student>();
        private string comments;

        public string UTI
        {
            get
            {
                return this.uti;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentNullException("Invalid Unique Text Idetifier!");
                }
                this.uti = value;
            }
        }

        private List<Student> SetOfStudents
        {
            get
            {
                return this.setOfStudents;
            }
            set
            {
                this.setOfStudents = value;
            }
        }

        private List<Teacher> SetOfTeachers
        {
            get
            {
                return this.setOfTeachers;
            }
            set
            {
                this.setOfTeachers = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                this.comments = value;
            }
        }

        public SchoolClass(string inputUTI, string inputComments, List<Teacher> inputSetOfTeachers, List<Student> inputSetOfStudents)
            : this(inputUTI, inputComments)
        {
            this.SetOfTeachers = inputSetOfTeachers;
            this.SetOfStudents = inputSetOfStudents;
        }

        public SchoolClass(string inputUTI, string inputComments = "No optional comments")
        {
            this.UTI = inputUTI;
        }

        public void AddComments(string inputComment)
        {
            this.Comments = inputComment;
        }

        public void RemoveComments()
        {
            this.Comments = string.Empty;
        }

        public void AddTeacher(Teacher inputTeacher)
        {
            this.SetOfTeachers.Add(inputTeacher);
        }

        public string DisplayTeachers()
        {
            StringBuilder listOfTeachers = new StringBuilder();
            int i = 0;  // At first was i=1, but I thought it would be confusing.

            foreach (var teacher in SetOfTeachers)
            {
                listOfTeachers.AppendLine(string.Format("{0}. {1}", i, teacher));
                i++;
            }

            return listOfTeachers.ToString();
        }

        public void RemoveTeacherAtPosition(int inputPosition)
        {
            if (this.SetOfTeachers.Count > 0 && inputPosition >= 0)
            {
                this.SetOfTeachers.RemoveAt(inputPosition);
            }
            else
            {
                throw new ArgumentException("Invalid position or Set of teachers is empty!");
            }
        }

        public void RemoveAllTeachers()
        {
            this.SetOfTeachers.Clear();
        }



        public void AddStudent(Student inputStudent)
        {
            this.SetOfStudents.Add(inputStudent);
        }

        public string DisplayStudents()
        {
            StringBuilder listOfStudents = new StringBuilder();
            int i = 0;  // At first was i=1, but I thought it would be confusing.

            foreach (var student in SetOfStudents)
            {
                listOfStudents.AppendLine(string.Format("{0}. {1}", i, student));
                i++;
            }

            return listOfStudents.ToString();
        }

        public void RemoveStudentAtPosition(int inputPosition)
        {
            if (this.SetOfStudents.Count > 0 && inputPosition >= 0)
            {
                this.SetOfStudents.RemoveAt(inputPosition);
            }
            else
            {
                throw new ArgumentException("Invalid position or Set of students is empty!");
            }
        }

        public void RemoveAllStudents()
        {
            this.SetOfStudents.Clear();
        }


        public override string ToString()
        {
            StringBuilder printSchoolClass = new StringBuilder();

            printSchoolClass.AppendLine("Class: " + this.UTI);
            printSchoolClass.AppendLine("Class teachers: ");
            printSchoolClass.AppendLine(DisplayTeachers());
            printSchoolClass.AppendLine("Class students: ");
            printSchoolClass.AppendLine(DisplayStudents());
            printSchoolClass.AppendLine("Additional comments: " + this.Comments);
            printSchoolClass.AppendLine();
            printSchoolClass.AppendLine(new string('-', 20));

            return printSchoolClass.ToString();
        }
    }
}
