namespace SchoolClasses
{
    using System;
    using System.Text;

    public class Discipline
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Invalid discipline!");
                }
                this.name = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Invalid number of lectures");
                }
                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentNullException("Invalid number of exercises");
                }
                this.numberOfExercises = value;
            }
        }

        public Discipline(string inputName, int inputNumberOfLectures, int inputNumberOfExercises)
        {
            this.Name = inputName;
            this.NumberOfLectures = inputNumberOfLectures;
            this.NumberOfExercises = inputNumberOfExercises;
        }

        public override string ToString()
        {
            StringBuilder discipline = new StringBuilder();

            discipline.AppendLine(this.Name);
            discipline.AppendLine("Number of lectures" + this.NumberOfLectures);
            discipline.AppendLine("Number of exercises: " + this.NumberOfExercises);

            return discipline.ToString();
        }
    }
}
