using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ado.NET_Connection
{
    internal class C001_Connection
    {

        public static void Main(String[] args)
        {
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Server=DESKTOP-EJJIOVD\\SQLEXPRESS;Database=Ado_Connection;Trusted_Connection=true");
            conn.Open();
            try
            {
                String query = "insert into Students values('Ayan',21)";
                cmd = new SqlCommand(query, conn);
                int i = cmd.ExecuteNonQuery();

                if (i != 0)
                {
                    Console.WriteLine("Query executed successfully");
                }
                else
                {
                    Console.WriteLine("Error in connection or query");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
