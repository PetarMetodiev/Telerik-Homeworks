namespace StudentClass
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private ulong ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private uint course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        public Student(string inputFirstName, string inputMiddleName, string inputLastName, ulong inputSSN, string inputPermanentAddress, string inputMobilePhone, string inputEmail, uint inputCourse, Specialty inputSpecialty, University inputUniversity, Faculty inputFaculty)
        {
            this.FirstName = inputFirstName;
            this.MiddleName = inputMiddleName;
            this.LastName = inputLastName;
            this.SSN = inputSSN;
            this.PermanentAddress = inputPermanentAddress;
            this.MobilePhone = inputMobilePhone;
            this.Email = inputEmail;
            this.Course = inputCourse;
            this.Specialty = inputSpecialty;
            this.University = inputUniversity;
            this.Faculty = inputFaculty;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                CheckName(value, 2);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                CheckName(value, 2);
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                CheckName(value, 2);
                this.lastName = value;
            }
        }

        public ulong SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                this.ssn = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            private set
            {
                CheckName(value, 10);
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            private set
            {
                CheckName(value, 10);
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                CheckName(value, 4);
                this.email = value;
            }
        }

        public uint Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                this.course = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            private set
            {
                this.specialty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            private set
            {
                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            private set
            {
                this.faculty = value;
            }
        }

        public override bool Equals(object obj)
        {
            var objAsStudent = obj as Student;

            if (this.FirstName == objAsStudent.FirstName && this.MiddleName == objAsStudent.MiddleName && this.LastName == objAsStudent.LastName && this.SSN == objAsStudent.SSN)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder studentInfo = new StringBuilder();

            studentInfo.AppendLine(string.Format("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            studentInfo.AppendLine(string.Format("SSN: " + this.SSN));
            studentInfo.AppendLine(string.Format("Permanent address: " + this.PermanentAddress));
            studentInfo.AppendLine(string.Format("Mobile phone: " + this.MobilePhone));
            studentInfo.AppendLine(string.Format("Email: " + this.Email));
            studentInfo.AppendLine(string.Format("Course: " + this.Course));
            studentInfo.AppendLine(string.Format("Specialty: " + this.Specialty));
            studentInfo.AppendLine(string.Format("University: " + this.University));
            studentInfo.AppendLine(string.Format("Faculty: " + this.Faculty));

            return studentInfo.ToString();
        }

        public override int GetHashCode()
        {
            return this.FirstName.Length ^ this.LastName.Length;
        }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !Student.Equals(firstStudent, secondStudent);
        }

        private void CheckName(string name, int minimumLength)
        {
            if (name.Length < minimumLength)
            {
                throw new ArgumentNullException("Invalid input!");
            }
        }

        public object Clone()
        {
            var clone = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, this.MobilePhone, this.Email, this.Course, this.Specialty, this.University, this.Faculty);

            return clone;
        }

        public int CompareTo(Student otherStudent)
        {
            if (this.FirstName.CompareTo(otherStudent.FirstName) != 0)
            {
                return this.FirstName.CompareTo(otherStudent.FirstName);
            }

            if (this.MiddleName.CompareTo(otherStudent.MiddleName) !=0)
            {
                return this.MiddleName.CompareTo(otherStudent.MiddleName);
            }

            if (this.LastName.CompareTo(otherStudent.LastName)!=0)
            {
                return this.LastName.CompareTo(otherStudent.LastName);
            }

            if (this.SSN.CompareTo(otherStudent.SSN) != 0)
            {
                return this.SSN.CompareTo(otherStudent.SSN);
            }

            return 0;
        }
    }
}
