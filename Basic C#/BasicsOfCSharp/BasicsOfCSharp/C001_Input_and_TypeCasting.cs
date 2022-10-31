/*
    The function of the Convert class is used for explicit type convertion :
    Type of functions available are :
    1. Convert.ToInt32() --> Converts String to Integer of 32 Signed Bits.
    2. Convert.ToInt64() --> Converts String to Integer of 63 Signed Bits.
    3. Convert.ToString() --> Converts any type of String data type
    4. Convert.ToDouble() --> Converts anytype to double
    5. Convert.ToUInt32() --> Converts a type to an unsigned long type.
 */

using System;
namespace BasicsOfCSharp
{
    internal class C001_Input_and_TypeCasting
    {
        public static void Main(String[] args)
        {
            Console.Write("Enter your name : ");
            String name = Console.ReadLine();
            Console.Write("Enter your age : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your marks obtained : ");
            double d = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Name : "+name+"\nRoll : "+a+"\nMarks :"+d);
            int z = 420;
            String z_name = Convert.ToString(z);
            Console.WriteLine(z);
        }
    }
}