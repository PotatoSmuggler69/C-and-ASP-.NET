using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfCSharp
{
    internal class C002_Inheritance
    {
        static void Main()
        {
            int readonlyArgument = 44;
            fun1(readonlyArgument);
            Console.WriteLine(readonlyArgument);
        }
        static void fun1(in int number)
        {
            int sum = number + 100;
            
            Console.WriteLine(sum);
        }
    }

}
