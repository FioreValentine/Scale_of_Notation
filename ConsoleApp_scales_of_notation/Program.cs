using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_scales_of_notation
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 345;
            DigitWithNotation dwn = DigitWithNotation.ToNewScale(a, 8);
            Console.WriteLine(a + " в десятичной системе");
            Console.WriteLine(dwn);
            Console.WriteLine(dwn.ToDenary() + " переведённый");
            Console.ReadKey();
        }
    }
}
