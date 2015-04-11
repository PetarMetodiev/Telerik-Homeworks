namespace SchoolClasses
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value == string.Empty || value.Length <2)
                {
                    throw new ArgumentOutOfRangeException("Invalid name!");
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
                if (value == string.Empty || value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Invalid name!");
                }
                this.lastName = value;
            }
        }

        public Person(string inputFirstName, string inputLastName)
        {
            this.FirstName = inputFirstName;
            this.LastName = inputLastName;
        }
    }
}
