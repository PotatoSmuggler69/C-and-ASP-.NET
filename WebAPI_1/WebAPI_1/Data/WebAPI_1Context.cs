using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Model;

namespace WebAPI_1.Data
{
    public class WebAPI_1Context : DbContext
    {
        public WebAPI_1Context (DbContextOptions<WebAPI_1Context> options)
            : base(options)
        {
        }

        public DbSet<WebAPI_1.Model.Cricketer> Cricketer { get; set; } = default!;
    }
}
