using LibraryManagement.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Web.Infrastructure
{
    public class DbObject : DbContext
    {
        public DbObject(DbContextOptions<DbObject> options):
            base(options)
        {

        }
        public DbSet<Book> BookTable { get; set; }
        public DbSet<Member> MemberTable { get; set; }
    }

}
