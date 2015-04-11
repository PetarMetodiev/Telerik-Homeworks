
// A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
// Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class CompanyManager
{
    static void Main()
    {
        Console.Title = "Company details";

        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Enter company phone number: ");      // The telephone number and fax are string, because there can be a + sign at the bigining
        string companyNumber = Console.ReadLine();          // Or can contain any other symbol

        Console.Write("Enter company fax number: ");
        string companyFax = Console.ReadLine();

        Console.Write("Enter company website: ");
        string companyWebSite = Console.ReadLine();

        Console.Write("Enter manager's first name: ");
        string managerFirst = Console.ReadLine();

        Console.Write("Enter manager's last name: ");
        string managerLast = Console.ReadLine();

        Console.Write("Enter manager's age: ");
        string managerAge = Console.ReadLine();
        uint age;

        while (!uint.TryParse(managerAge, out age))
        {
            Console.Write("Enter manager's age: ");
            managerAge = Console.ReadLine();
        }

        Console.Write("Enter manager's phone number: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("Data about our company:");
        Console.WriteLine("We are \"{0}\". We are located at {1}. If you want you can call us on {2} whenever you want. Of course you can send us a fax on {3}. If you need more info about us, you can head over to our website - {4}.", companyName, companyAddress, companyNumber, companyFax, companyWebSite);
        Console.WriteLine("Our manager {0} {1} is always ready to help! He is {2} years old. Don't let the age fool you! He is available 24/7 on his personal phone {3}", managerFirst, managerLast, managerAge, managerPhone);
    }
}
