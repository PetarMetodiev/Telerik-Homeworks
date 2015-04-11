namespace BankAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Deposit : Account
    {
        public const decimal baseInterestRate = 0.1M; // 10%

        private decimal depositAmmount;
        private decimal drawAmmount;

        private decimal DepositAmmout
        {
            get
            {
                return this.depositAmmount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Invalid deposit ammount!");
                }
                this.depositAmmount = value;
            }
        }

        private decimal DrawAmmount
        {
            get
            {
                return this.drawAmmount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Invalid draw ammount!");
                }
                this.drawAmmount = value;
            }
        }

        public Deposit(string inputName, decimal inputBalance, int inputMonths)
            : base(inputName, inputBalance, inputMonths)
        {
            if (inputBalance > 0 && inputBalance < 1000)
            {
                this.InterestRate = 0;
            }
            else
            {
                this.InterestRate = baseInterestRate;
            }
        }

        public override void DepositMoney(decimal inputAmmount)
        {
            CheckInputAmmount(inputAmmount);

            this.Balance += inputAmmount;

            if (this.Balance < 0 || this.Balance >= 1000)
            {
                this.InterestRate = baseInterestRate;
            }
            else
            {
                this.InterestRate = 0;
            }
        }

        public override void WithdrawMoney(decimal inputAmmount)
        {
            CheckInputAmmount(inputAmmount);

            this.Balance -= inputAmmount;

            if (this.Balance < 0 || this.Balance >= 1000)
            {
                this.InterestRate = baseInterestRate;
            }
            else
            {
                this.InterestRate = 0;
            }
        }
        
        //protected override decimal InterestAmmount()
        //{
        //    return base.InterestAmmount();
        //}
    }
}
