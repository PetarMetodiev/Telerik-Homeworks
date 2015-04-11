namespace StudetsAndWorkers
{
    using System;
    using System.Text;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string inputFirstName, string inputLastName)
        {
            this.FirstName = inputFirstName;
            this.LastName = inputLastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.firstName = value;
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
                if (value.Length < 2)
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                this.lastName = value;
            }
        }

    }
}
