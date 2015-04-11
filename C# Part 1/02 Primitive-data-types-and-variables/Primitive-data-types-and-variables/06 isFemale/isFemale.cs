using System;

class isFemale
{
    static void Main()
    {
        Console.Title = "Gender check";
        Console.WriteLine("I am a boy. True or false?");
        string answerstring = Console.ReadLine();
        while (answerstring != "true" && answerstring != "false")
        {
            Console.WriteLine("Please enter True or False! \n");
            Console.WriteLine("I am a boy. True or false?");
            answerstring = Console.ReadLine();
        }
        bool answer = bool.Parse(answerstring);
        if (answer == true)
        {
            Console.WriteLine("That is right!");
        }
        else
        {
            Console.WriteLine("Next life maybe :) ");
        }
    }
}
