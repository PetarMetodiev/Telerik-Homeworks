namespace BankAccounts
{
    using System;
    using System.Collections.Generic;

    class Start
    {
        static void Main()
        {
            Bank secureBank = new Bank("Secure Bank");

            Customer firstCustomer = new Customer("Ivan Vasilev", CustomerType.Individual);

            Account firstDeposit = new Deposit("Savngs", 55.05M, 65);
            Account anotherFirstDeposit = new Deposit("Savngs", 55555.05M, 65);
            Account firstLoan = new Loan("Small bussiness", 8875.06M, 96, firstCustomer.CustomerType);
            Account firstMortgage = new Mortgage("Family house",12365.36M,36,firstCustomer.CustomerType);

            Customer secondCustomer = new Customer("Fast petrol", CustomerType.Company);
            Account secondDeposit = new Deposit("Just in case", 66652.32M, 124);
            Account secondLoan = new Loan("Expansion", 56654M, 36, secondCustomer.CustomerType);
            Account secondMortgage = new Mortgage("Factory", 665897M, 36, secondCustomer.CustomerType);

            secureBank.AddAccountToCustomer(firstCustomer, firstDeposit);
            secureBank.AddAccountToCustomer(firstCustomer, anotherFirstDeposit);
            secureBank.AddAccountToCustomer(firstCustomer, firstLoan);
            secureBank.AddAccountToCustomer(firstCustomer, firstMortgage);

            secureBank.AddAccountToCustomer(secondCustomer, secondDeposit);
            secureBank.AddAccountToCustomer(secondCustomer, secondLoan);
            secureBank.AddAccountToCustomer(secondCustomer, secondMortgage);

            Console.WriteLine(secureBank);

            // Console.WriteLine(secureBank.GetInterestRateForCustomerAccountAtPosition(secondCustomer, 2));
            // Console.WriteLine(secureBank.GetInterestAmmountForCustomerAccountAtPosition(secondCustomer, 2));
            // Console.WriteLine(secureBank.GetBalanceForCustomerAccountAtPosition(secondCustomer, 2));
        }
    }
}
