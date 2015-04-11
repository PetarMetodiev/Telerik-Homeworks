using System;
using System.Text;

class ASCII
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Title = "ASCII Table";
        int a = 0;
        for (int i = 0; i < 255; i++)
        {
            Console.WriteLine((char)a + " ");
            a++;
        }
        Console.WriteLine();
    }
}
