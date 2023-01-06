using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Univ.web.Models;

namespace Univ.web.Data
{
    public class UnivwebContext : DbContext
    {
        public UnivwebContext (DbContextOptions<UnivwebContext> options)
            : base(options)
        {
        }

        public DbSet<Univ.web.Models.Food> Food { get; set; } = default!;
    }
}
