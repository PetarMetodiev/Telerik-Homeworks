using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    internal class Mortgage : Account
    {
        public const decimal baseInterestRate = 0.12M;
        private const int halfInterestMonthsCompany = 12;
        private const int noInterestMonthsIndividual = 6;

        public Mortgage(string inputName, decimal inputBalance, int inputMonths, CustomerType inputCustomerType)
            : base(inputName, inputBalance, inputMonths, inputCustomerType)
        {
            this.InterestRate = baseInterestRate;
            if (inputCustomerType == CustomerType.Company)
            {
                if (this.Months <= halfInterestMonthsCompany)
                {
                    this.InterestRate /= 2;
                }
                else
                {
                    this.InterestRate = (halfInterestMonthsCompany * (baseInterestRate / 2) + (this.Months - halfInterestMonthsCompany) * baseInterestRate) / this.Months;
                }
            }
            else if (inputCustomerType == CustomerType.Individual)
            {
                if (this.Months <= noInterestMonthsIndividual)
                {
                    this.InterestRate = 0;
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
