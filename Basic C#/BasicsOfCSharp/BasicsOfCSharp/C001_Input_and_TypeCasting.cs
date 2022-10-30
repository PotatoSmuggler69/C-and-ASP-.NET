
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