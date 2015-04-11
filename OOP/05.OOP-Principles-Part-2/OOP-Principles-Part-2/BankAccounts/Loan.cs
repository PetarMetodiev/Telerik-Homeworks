using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    internal class Loan : Account
    {
        public const decimal baseInterestRate = 0.15M;
        private const int noInterestMonthsCompany = 2;
        private const int noInterestMonthsIndividual = 3;

        public Loan(string inputName, decimal inputBalance, int inputMonths, CustomerType inputCustomerType)
            : base(inputName, inputBalance, inputMonths, inputCustomerType)
        {
            this.InterestRate = baseInterestRate;
            if (inputCustomerType == CustomerType.Company)
            {
                if (inputMonths <= noInterestMonthsCompany)
                {
                    this.Months = 0;
                }
                else
                {
                    this.Months = inputMonths - noInterestMonthsCompany;
                }
            }
            else if (inputCustomerType == CustomerType.Individual)
            {
                if (inputMonths <= noInterestMonthsIndividual)
                {
                    this.Months = 0;
                }
                else
                {
                    this.Months = inputMonths - noInterestMonthsIndividual;
                }
            }
        }

        //protected override decimal InterestAmmount()
        //{
        //    return base.InterestAmmount();
        //}

    }
}
