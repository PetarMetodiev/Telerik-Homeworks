namespace SchoolClasses
{
    using System;
    using System.Text;

    public class Student : Person, IPerson, ICommentable
    {
        private int ucn; // Uniqie class number.
        private string comments;

        public int UCN
        {
            get
            {
                return this.ucn;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid Unique class number!");
                }
                this.ucn = value;
            }
        }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
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

        public Student(string inputFirstName, string inputLastName, int inputUCN)
            : this(inputFirstName, inputLastName, inputUCN, "No optional comments")
        {
        }

        public Student(string inputFirstName, string inputLastName, int inputUCN, string inputComments)
            : base(inputFirstName, inputLastName)
        {
            this.UCN = inputUCN;
            this.Comments = inputComments;
        }

        public void AddComments(string inputComment)
        {
            this.Comments = inputComment;
        }

        public void RemoveComments()
        {
            this.Comments = string.Empty;
        }

        public override string ToString()
        {
            StringBuilder student = new StringBuilder();

            student.AppendLine(this.Name);
            student.AppendLine("Unique class number: "+this.UCN);
            student.AppendLine("Optional comments: " + this.Comments);

            return student.ToString();
        }
    }
}
