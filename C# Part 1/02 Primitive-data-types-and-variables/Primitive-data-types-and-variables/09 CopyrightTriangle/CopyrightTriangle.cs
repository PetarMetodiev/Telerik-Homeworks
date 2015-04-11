using System;
using System.Text;

class CopyrightTriangle
{
    static void Main()
    {
        Console.Title = "CopyRight Triangle";
        Console.OutputEncoding = Encoding.Unicode;
        int cols, rows, space, rowsnum, elementsnum;
        Console.Write("Enter number of elements: ");
        string elements = Console.ReadLine();
        while (int.TryParse(elements, out elementsnum) == false || (Math.Sqrt(elementsnum) % 1 != 0))   //Проверява се дали въведеното число ще удовлетвори алгоритъмът
        {
            if (int.TryParse(elements, out elementsnum) == false)
            {
                Console.Write("Enter number of elements(only integers): ");
                elements = Console.ReadLine();
            }
            else
            {
                Console.Write("Enter number of elements(with exact square root): ");
                elements = Console.ReadLine();
            }
        }
        if (elementsnum == 4)                           // Прави се проверка ако са въведени 4 елемента, защото при 4 алгоритъмът не работи
        {
            rows = (elementsnum / 3) + 1;               
        }
        else
        {
            rows = elementsnum / 3;                     // Определят се броят на елементите спрямо редовете
        }
        rowsnum = rows + 1;                             // Програмата брои редовете от зад напред
        cols = 1;                                       // Съхранява броят на колоните
        space = rows - 1;                               // Съхранява броят на отстъпите
        for (int i = 0; i < rows; i++)                  // Цикъл по редове
        {
            for (int j = 0; j < space; j++)             // Цикъл за остстъпите
            {
                space = rowsnum - 1;                    // При всяко завъртане разстоянията намаляват с 1
                Console.Write(" ");
            }
            for (int k = 0; k < cols; k++)              // Цикъл за изписване на символът Copyright
            {
                Console.Write('\u00A9');
            }
            Console.WriteLine();                        // След всеки ред се отива на нов ред
            cols += 2;                                  // При всяко завъртане колоните се увеличават с 2, защото редът расте симетрично
            rowsnum--;                                  // Слиза се с един ред по-надолу
        }
    }
}