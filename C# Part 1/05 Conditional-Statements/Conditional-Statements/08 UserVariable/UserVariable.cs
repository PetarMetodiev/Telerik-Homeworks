
// Write a program that, depending on the user's choice inputs int, double or string variable. 
// If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
// The program must show the value of that variable as a console output. Use switch statement.

using System;

    class UserVariable
    {
        static void Main()
        {
            Console.Title = "int, double, or string?";

            Console.WriteLine("What type of variable would you like to create?");
            Console.WriteLine("Enter 1 for int, 2 for double, 3 for string.");
            Console.WriteLine();                                                    // Adding some extra space between the lines to make it look better
            Console.Write("What is your choice? ");
            string choiceString = Console.ReadLine();
            int choice;

            while (!(int.TryParse(choiceString, out choice)))
            {
                Console.Write("What is your choice(numbers only)?");
                choiceString = Console.ReadLine();
            }

            Console.WriteLine();                                                    // Everywhere these are added to make the program easier to read by the user

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You have chosen an int variable.");
                    Console.WriteLine();
                    Console.Write("Enter value for the variable: ");
                    string intValueString = Console.ReadLine();
                    int intValue;

                    while (!(int.TryParse(intValueString, out intValue)))
                    {
                        Console.Write("Enter valid value for integer variable: ");
                        intValueString = Console.ReadLine();
                    }

                    intValue++;

                    Console.WriteLine("The new value for your variable is {0}", intValue);
                    break;

                case 2:
                    Console.WriteLine("You have chosen a double variable.");
                    Console.WriteLine();
                    Console.Write("Enter value for the variable: ");
                    string doubleValueString = Console.ReadLine();
                    double doubleValue;

                    while (!(double.TryParse(doubleValueString, out doubleValue)))
                    {
                        Console.Write("Enter valid value for integer variable: ");
                        doubleValueString = Console.ReadLine();
                    }

                    doubleValue++;

                    Console.WriteLine("The new value for your variable is {0}", doubleValue);
                    break;
                case 3:
                    Console.WriteLine("You have chosen a string variable.");
                    Console.WriteLine();
                    Console.Write("Please enter a desired string: ");
                    string stringVariable = Console.ReadLine();
                    stringVariable = stringVariable + "*";
                    Console.WriteLine("Your new string variable is {0}", stringVariable);
                    break;
                default:
                    Console.WriteLine("Unknown type of variable requested.");
                    break;
            }
        }
    }
