using System;

class EmployeeRecord
{
    static void Main()
    {
        Console.Title = "Single employee's record";
        string firstName, familyName, genderString, employeeNumberString;
        char gender;
        int employeeNumber;
        string idString;                                          // ЕГН-то е декларирано като string, защото не се използва за математическа обработка
        Console.Write("Enter employee's first name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter employee's family name: ");
        familyName = Console.ReadLine();
        Console.Write("Enter employee's gender: ");
        genderString = Console.ReadLine();
        gender = char.Parse(genderString);
        Console.Write("Enter employee's ID: ");
        idString = Console.ReadLine();
        Console.Write("Enter employee's number: ");
        employeeNumberString = Console.ReadLine();
        employeeNumber = int.Parse(employeeNumberString);
        Console.WriteLine();
        Console.WriteLine("Employee data");
        Console.WriteLine("Name: {0} {1}", firstName, familyName);
        Console.WriteLine("Gender: {0}", gender);
        Console.WriteLine("ID number: {0}", idString);
        Console.WriteLine("Unique employee number: {0}", employeeNumber);
    }
}
