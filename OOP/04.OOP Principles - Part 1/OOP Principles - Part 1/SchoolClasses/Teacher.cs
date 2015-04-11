namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Person, IPerson, ICommentable
    {
        private string comments;
        private List<Discipline> setOfDisciplines = new List<Discipline>();

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

        private List<Discipline> SetOfDisciplines
        {
            get
            {
                return this.setOfDisciplines;
            }
            set
            {
                this.setOfDisciplines = value;
            }
        }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public Teacher(string inputFirstName, string inputLastName, List<Discipline> inputSetOfDisciplines)
            : this(inputFirstName, inputLastName, inputSetOfDisciplines, "No optional comments")
        {
        }

        public Teacher(string inputFirstName, string inputLastName, List<Discipline> inputSetOfDisciplines, string inputComments)
            : base(inputFirstName, inputLastName)
        {
            this.SetOfDisciplines = inputSetOfDisciplines;
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

        public void AddDiscipline(Discipline inputDiscipline)
        {
            this.SetOfDisciplines.Add(inputDiscipline);
        }

        public string DisplayDisciplines()
        {
            StringBuilder listOfDisciplines = new StringBuilder();
            int i = 0;  // At first was i=1, but I thought it would be confusing.

            foreach (var discipline in setOfDisciplines)
            {
                listOfDisciplines.AppendLine(string.Format("{0}. {1}", i, discipline));
                i++;
            }

            return listOfDisciplines.ToString();
        }

        public void RemoveDisciplineAtPosition(int inputPosition)
        {
            if (this.SetOfDisciplines.Count > 0 && inputPosition >= 0)
            {
                this.SetOfDisciplines.RemoveAt(inputPosition);
            }
            else
            {
                throw new ArgumentException("Invalid position or Set of disciplines is empty!");
            }
        }

        public void RemoveAllDisciplines()
        {
            this.SetOfDisciplines.Clear();
        }

        public override string ToString()
        {
            StringBuilder teacher = new StringBuilder();

            teacher.AppendLine(this.Name);
            teacher.AppendLine("Teaches: ");

            foreach (var discipline in this.SetOfDisciplines)
            {
                teacher.AppendLine(discipline.ToString());
            }

            teacher.AppendLine("Optional comments: " + this.Comments);

            return teacher.ToString();
        }
    }
}
