using ApiProject.web.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.web.Insfrastructure
{
    public class DbInfo : DbContext 
    {
        public DbInfo(DbContextOptions<DbInfo> options)
            : base (options)
        {

        }
        public DbSet<ClientInfo> ClientTable { get; set; }
    }
}
