using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Ado.NET_Connection
{
    internal class C003_Selection
    {
        public static void Main(String[] args) {
            C001_Connection obj = new C001_Connection();
            String query = "select * from Students";
            obj.cmd = new SqlCommand(query,obj.conn);
            SqlDataReader note =obj.cmd.ExecuteReader();
            while (note.Read()) {
                Console.WriteLine(note[0]+"\t\t" + note[1]);
            }

        }
    }
}
