using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ado.NET_Connection
{
    internal class C002_Printing_Whole_Table
    {
        public static void main() { 
            C003_Connect obj = new C003_Connect();
            Console.Write("Enter your query : ");
            String query = Console.ReadLine();
            obj.cmd = new SqlCommand(query);

        }
    }
}
