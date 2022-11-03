using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ado.NET_Connection
{
    internal class C003_Connect
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        public C003_Connect() {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-EJJIOVD\\SQLEXPRESS;Database=Ado_Connection;Trusted_Connection=true");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error :" + e);
            }
            
        } 
    }
}
