namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Bank
    {
        private string name;
        private Dictionary<Customer, List<Account>> customerAccounts = new Dictionary<Customer, List<Account>>();


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
                    throw new ArgumentNullException("Invalid bank name!");
                }
                this.name = value;
            }
        }

        private Dictionary<Customer, List<Account>> CustomerAccounts
        {
            get
            {
                return this.customerAccounts;
            }
            set
            {
                this.customerAccounts = value;
            }
        }

        public Bank(string inputName)
        {
            this.Name = inputName;
        }

        private void AddCustomer(Customer inputCustomer)
        {
            this.CustomerAccounts.Add(inputCustomer, new List<Account>());
        }

        public void AddAccountToCustomer(Customer inputCustomer, Account inputAccount)
        {
            bool newCustomer = this.CustomerAccounts.ContainsKey(inputCustomer);
            if (!newCustomer)
            {
                this.AddCustomer(inputCustomer);
            }
            CustomerAccounts[inputCustomer].Add(inputAccount);
        }

        public void DepositMoneyToAccount(Customer inputCustomer, int inputAccountPosition, decimal inputAmmount)
        {
            this.CustomerAccounts[inputCustomer][inputAccountPosition].DepositMoney(inputAmmount);
        }

        // Not sure if the best implementation.
        public void WithdrawMoneyFromDeposit(Customer inputCustomer, int inputAccountPosition, decimal inputAmmount)
        {
            this.CustomerAccounts[inputCustomer][inputAccountPosition].WithdrawMoney(inputAmmount);
        }

        public decimal GetInterestRateForCustomerAccountAtPosition(Customer inputCustomer, int inputAccountPosition)
        {
            decimal interestRate = this.CustomerAccounts[inputCustomer][inputAccountPosition].InterestRate;
            return interestRate;
        }

        public decimal GetInterestAmmountForCustomerAccountAtPosition(Customer inputCustomer, int inputAccountPosition)
        {
            decimal interestAmmount = this.CustomerAccounts[inputCustomer][inputAccountPosition].GetInterestAmmount();
            return interestAmmount;
        }

        public decimal GetBalanceForCustomerAccountAtPosition(Customer inputCustomer, int inputAccountPosition)
        {
            decimal balance = this.CustomerAccounts[inputCustomer][inputAccountPosition].GetBalance();
            return balance;
        }

        public override string ToString()
        {
            StringBuilder printInfo = new StringBuilder();

            foreach (var customer in this.CustomerAccounts.Keys)
            {
                printInfo.AppendLine(customer.ToString());

                foreach (var account in CustomerAccounts[customer])
                {
                    printInfo.AppendLine(account.ToString());
                }

                //printInfo.AppendLine(this.CustomerAccounts[customer].ToString());

                printInfo.AppendLine(new String('-', 20));
            }

            return printInfo.ToString();
        }

    }
}
