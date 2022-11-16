using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio_Website.Models;

namespace Portfolio_Website.Data
{
    public class Portfolio_WebsiteContext : DbContext
    {
        public Portfolio_WebsiteContext (DbContextOptions<Portfolio_WebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio_Website.Models.Contact> Contact { get; set; } = default!;
    }
}
