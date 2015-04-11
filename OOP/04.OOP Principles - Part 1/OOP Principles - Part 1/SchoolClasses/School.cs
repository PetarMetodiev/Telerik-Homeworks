namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class School
    {
        private string schoolName;
        private Dictionary<string, SchoolClass> dictOfSchoolClasses = new Dictionary<string, SchoolClass>();

        public string SchoolName
        {
            get
            {
                return this.schoolName;
            }
            private set
            {
                if (value.Length > 1)
                {
                    this.schoolName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid school name!");
                }
            }
        }

        public Dictionary<string, SchoolClass> DictOfSchoolClasses
        {
            get
            {
                return this.dictOfSchoolClasses;
            }
            set
            {
                this.dictOfSchoolClasses = value;
            }
        }

        public School(string inputSchoolName)
        {
            this.SchoolName = inputSchoolName;
        }

        public void AddSchoolClass(string inputUTI)
        {
            this.DictOfSchoolClasses.Add(inputUTI, new SchoolClass(inputUTI));
        }

        public void AddTeacherToClass(string inputClassName, Teacher inputTeacher)
        {
            this.DictOfSchoolClasses[inputClassName].AddTeacher(inputTeacher);
        }

        public void AddStudentToClass(string inputClassName, Student inputStudent)
        {
            this.DictOfSchoolClasses[inputClassName].AddStudent(inputStudent);
        }

        public void AddCommentsToClass(string inputClassName, string inputComments)
        {
            this.DictOfSchoolClasses[inputClassName].AddComments(inputComments);
        }

        public void RemoveSchoolClass(string inputUTI)
        {
            this.DictOfSchoolClasses.Remove(inputUTI);
        }

        public void RemoveTeacherFromClassAtPosition(string inputClassName, int inputPosition)
        {
            this.DictOfSchoolClasses[inputClassName].RemoveTeacherAtPosition(inputPosition);
        }

        public void RemoveAllTeachersFromClass(string inputClassName)
        {
            this.DictOfSchoolClasses[inputClassName].RemoveAllTeachers();
        }

        public void RemoveStudentFromClassAtPosition(string inputClassName, int inputPosition)
        {
            this.DictOfSchoolClasses[inputClassName].RemoveStudentAtPosition(inputPosition);
        }

        public void RemoveAllStudentsFromClass(string inputClassName)
        {
            this.DictOfSchoolClasses[inputClassName].RemoveAllStudents();
        }

        public void RemoveCommentsFromClass(string inputClassName)
        {
            this.DictOfSchoolClasses[inputClassName].RemoveComments();
        }

        public override string ToString()
        {
            StringBuilder school = new StringBuilder();
            school.AppendLine(string.Format("School name: " + this.SchoolName));
            school.AppendLine();
            foreach (var schoolClass in DictOfSchoolClasses.Values)
            {
                school.AppendLine(schoolClass.ToString());
            }
            school.AppendLine();

            return school.ToString();
        }
    }
}
