
// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

using System;

class ChangeMultipleBits
{
    static void Main()
    {
        Console.Title = "Bit exchange";

        Console.Write("Enter integer: ");
        string numString = Console.ReadLine();
        int num;

        while ((int.TryParse(numString, out num)) == false)
        {
            Console.Write("Enter integer: ");
            numString = Console.ReadLine();
        }

        Console.WriteLine("{1} is binary representation of {0}", num, Convert.ToString(num, 2).PadLeft(32, '0'));

        int position3 = 3;                  // Задаване на позиция
        int position24 = 24;                // Задаване на позиция

        int mask3 = 7 << position3;         // За маските се използва числото 7, защото в двоична бройна система е 111
        int mask24 = 7 << position24;       // Удобно е, защото не се налага да се декларират 6 отделни променливи за всяка позиция, а само 2 за двете тройки

        int getNums3 = num & mask3;         // Извличане на битовете от 3, 4, 5 позиция
        int getNums24 = num & mask24;       // Извличане на битовете от 24, 25, 26 позиция
        int nullify = (num & ~mask3) & ~mask24;      // Зануляване на битовете в нужните позиции

        int mask3a = (getNums3 >> position3) << position24;         // Преместване на битовете в новите позиции
        int mask24a = (getNums24 >> position24) << position3;       // Преместване на битовете в новите позиции
        int result = (nullify | mask3a) | mask24a;                  // Окончателна размяна на битовете

        Console.WriteLine("{1} is binary representation of {0}", result, Convert.ToString(result, 2).PadLeft(32, '0'));
    }
}