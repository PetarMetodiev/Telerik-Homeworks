
// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;

class CheckBrackets
{
    static bool CheckBracketsMethod(string expression)
    {
        char openBracket = '(';
        char closeBracket = ')';

        // Expression without brackets.
        if (!expression.Contains(openBracket.ToString()) && !expression.Contains(closeBracket.ToString()))
        {
            return false;
        }

        int counterOpenBrackets = 0;
        int counterCloseBrackets = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == openBracket)
            {
                counterOpenBrackets++;
            }
            if (expression[i] == closeBracket)
            {
                counterCloseBrackets++;
            }
        }

        // )(
        if (expression.IndexOf(openBracket) > expression.IndexOf(closeBracket))
        {
            return false;
        }

        // ((asd)
        if (counterCloseBrackets != counterOpenBrackets)
        {
            return false;
        }

        // ((()()))()(

        bool[] checkedValues = new bool[expression.Length];

        int indexOfOpenBracket = 0;
        int indexOfCloseBracket = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            indexOfOpenBracket = expression.IndexOf(openBracket, i);

            if (indexOfOpenBracket >= 0)
            {
                checkedValues[indexOfOpenBracket] = true;
            }

            indexOfCloseBracket = expression.IndexOf(closeBracket, i);

            if (indexOfCloseBracket >= 0)
            {
                checkedValues[indexOfCloseBracket] = true;
            }

            if ((indexOfOpenBracket > indexOfCloseBracket) && !checkedValues[indexOfCloseBracket] && !checkedValues[indexOfOpenBracket])
            {
                return false;
            }
        }

        // Check if an opened bracket has been closed.

        return true;
    }

    static void Main()
    {
        Console.Title = "Check the brackets";

        Console.Write("Enter expression to be checked: ");
        string expression = Console.ReadLine();
        bool checkBrackets = CheckBracketsMethod(expression);

        if (checkBrackets)
        {
            Console.WriteLine("The entered expression has valid arrangement of the brackets.");
        }
        else
        {
            Console.WriteLine("The entered expression does not have valid arrangement of the brackets.");
        }
    }
}