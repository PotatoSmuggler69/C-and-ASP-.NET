using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Self1.Models;

namespace Self1.Data
{
    public class Self1Context : DbContext
    {
        public Self1Context (DbContextOptions<Self1Context> options)
            : base(options)
        {
        }

        public DbSet<Self1.Models.Form> Form { get; set; } = default!;
    }
}
