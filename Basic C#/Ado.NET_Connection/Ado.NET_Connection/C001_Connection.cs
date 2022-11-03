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
        internal SqlConnection conn;
        internal SqlCommand cmd;
        public C001_Connection() {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-EJJIOVD\\SQLEXPRESS;Database=Ado_Connection;Trusted_Connection=true");
                conn.Open();
            }
            catch (Exception e) { 
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
