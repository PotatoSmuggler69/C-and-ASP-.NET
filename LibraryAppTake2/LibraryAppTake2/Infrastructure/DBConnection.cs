using Microsoft.EntityFrameworkCore;

namespace LibraryAppTake2.Infrastructure
{
    public class DBConnection : DbContext
    {
        public DBConnection(DbContextOptions<DBConnection> options)
        : base(options)
        {

        }

    }
}
