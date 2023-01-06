using System;
namespace ErrorLogging {
    public class Program
    {

        static void Main(string[] args)
        {


            try
            {
                int[] arr = new int[5] { 12, 45, 67, 89, 25 };
                int pos = 6;
                if (pos >= 5)
                {
                    throw new Exception("Invalid Array Index");
                }
            }
            catch (Exception ex)
            {
                new Error(ex);
            }

        }

       
    }



}






