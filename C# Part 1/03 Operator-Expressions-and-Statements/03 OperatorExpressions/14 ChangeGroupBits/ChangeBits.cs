
//* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

using System;

class ChangeBits
{
    static void Main()
    {
        Console.Title = "Exhange selected bits";

        Console.Write("Enter integer, num = ");
        string numString = Console.ReadLine();
        int num;

        while ((int.TryParse(numString, out num) == false))
        {
            Console.Write("Enter valid integer, num = ");
            numString = Console.ReadLine();
        }

        Console.Write("Enter position for first group, p = ");
        string pString = Console.ReadLine();
        int p;

        while ((int.TryParse(pString, out p) == false) || (p < 0))
        {
            Console.Write("Enter position for first group (p > 0), p = ");      
            pString = Console.ReadLine();                                       
        }                                                                       

        Console.Write("Enter position for second group, q = ");
        string qString = Console.ReadLine();
        int q;

        while ((int.TryParse(qString, out q) == false) || (q < 0))
        {
            Console.Write("Enter position for second group (q > 0), q = ");
            qString = Console.ReadLine();
        }

        Console.Write("Enter length of group, k = ");                   // Дължината на участъка с битове се брои от дясно на ляво
        string kString = Console.ReadLine();
        int k;

        while ((int.TryParse(kString, out k) == false) || (k < 0))
        {
            Console.Write("Enter length of group (k > 0), p = ");
            kString = Console.ReadLine();
        }

        int maskp = 0;                                                  // Маска, в която ще се запаметят битовете от първата група
        int mask;

        for (int i = 0; i < k; i++)
        {
            mask = 1 << p + i;                                          // При всяко завъртане на цикъла се добавя по един бит за позиция
            maskp = maskp | mask;                                       // Присвояване на новата стойност за маската
        }

        int maskq = 0;

        for (int i = 0; i < k; i++)
        {
            mask = 1 << q + i;
            maskq = maskq | mask;
        }

        int maskOnes = maskp | maskq;                                   // Обединяване на двете маски (използва се само за да се знаят местата на нужните битове
        maskOnes = ~maskOnes;                                           // Маската се обръща, за да може на нужните места да има 0
        
        maskp = num & maskp;                                            // Взимане на битовете от въведенто число
        maskp = maskp >> p;                                             // Връщане до нулева позиция
        maskp = maskp << q;                                             // Изместване до новата позиция

        maskq = num & maskq;
        maskq = maskq >> q;
        maskq = maskq << p;

        mask = maskq | maskp;                                           // Обединяване на двете маски в една

        int result = num & maskOnes;                                    // Зануляване на местата на групите
        result = result | mask;                                         // Окончателна размяна на битовете

        Console.WriteLine("{0} is the binary representation of {1}", Convert.ToString(num, 2).PadLeft(32, '0'), num);
        Console.WriteLine("{0} is the binary representation of {1}", Convert.ToString(result, 2).PadLeft(32, '0'), result);
    }
}
