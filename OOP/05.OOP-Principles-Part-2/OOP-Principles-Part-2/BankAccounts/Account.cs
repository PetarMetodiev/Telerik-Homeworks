namespace BankAccounts
{
    using System;
    using System.Text;

    public abstract class Account
    {
        private CustomerType customerType;
        private decimal balance;
        private decimal interestRate;
        private string name;
        private int months;

        protected CustomerType CustomerType
        {
            get
            {
                return this.customerType;
            }
            set
            {
                this.customerType = value;
            }
        }

        protected decimal Balance
        {
            get
            {
                return Decimal.Round(this.balance, 4);
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return Decimal.Round(this.interestRate, 3);
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Invalid interest rate!");
                }
                this.interestRate = value;
            }
        }

        protected string Name
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

        protected int Months
        {
            get
            {
                return this.months;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Invalid number of months!");
                }
                this.months = value;
            }
        }

        public Account(string inputName, decimal inputBalance, int inputMonths, CustomerType inputCustomerType = CustomerType.Individual)
        {
            this.Name = inputName;
            this.CustomerType = inputCustomerType;
            this.Balance = inputBalance;
            this.Months = inputMonths;
        }

        public decimal GetBalance()
        {
            decimal balance = this.Balance;
            return Balance;
        }

        public virtual decimal GetInterestAmmount()
        {
            decimal interestAmmount = this.Months * this.InterestRate;
            return interestAmmount;
        }

        protected void CheckInputAmmount(decimal inputAmmount)
        {
            if (inputAmmount <= 0)
            {
                throw new ArgumentNullException("Invalid number of months!");
            }
        }

        public override string ToString()
        {
            StringBuilder printAccount = new StringBuilder();
            printAccount.AppendLine(this.GetType().Name);
            printAccount.AppendLine("Account name: " + this.Name);
            printAccount.Append("Balance: " + Decimal.Round(this.Balance, 4));
            printAccount.AppendLine();
            return printAccount.ToString();
        }

        public virtual void DepositMoney(decimal inputAmmount)
        {
            CheckInputAmmount(inputAmmount);

            this.Balance += inputAmmount;
        }

        public virtual void WithdrawMoney(decimal inputAmmount)
        {
            throw new InvalidOperationException("Invalid withdraw!");
        }
    }
}
