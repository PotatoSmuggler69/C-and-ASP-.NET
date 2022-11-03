using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ado.NET_Connection
{
    internal class C002_Insertion
    {
        public static void main(String[] args) {
            try
            {
                C001_Connection obj = new C001_Connection();
                String query = "insert into Students values('Shreya',11)";
                
                obj.cmd = new SqlCommand(query, obj.conn);

                int i = obj.cmd.ExecuteNonQuery();
                if (i != 0) Console.WriteLine("Query executed Successfully");
                else Console.WriteLine("Something went wrong");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }




        }
    }
}
