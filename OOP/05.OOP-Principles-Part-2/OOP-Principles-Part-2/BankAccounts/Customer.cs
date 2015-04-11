using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class Customer
    {
        private string name;
        private CustomerType customerType;

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
                    throw new ArgumentNullException("Invalid name!");
                }
                this.name = value;
            }
        }

        public Customer(string inputName, CustomerType inputCustomerType)
        {
            this.Name = inputName;
            this.CustomerType = inputCustomerType;
        }

        public CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }
            private set
            {
                this.customerType = value;
            }
        }

        public override string ToString()
        {
            return this.CustomerType + ", " + this.Name + ":";
        }
    }
}
