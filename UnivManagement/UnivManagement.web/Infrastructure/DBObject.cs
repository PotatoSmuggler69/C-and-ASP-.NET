using Microsoft.EntityFrameworkCore;
using UnivManagement.web.Models;

namespace UnivManagement.web.Infrastructure
{
    public class DBObject : DbContext
    {
        public DBObject(DbContextOptions<DBObject> options)
            : base(options)
        {

        }
        public DbSet<PeopleInfo> PeopleInfoTable { get; set; }
    }
}
