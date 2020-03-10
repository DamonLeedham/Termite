using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCRUDTest.Models
{
    public class StuffContext : DbContext
    {
        public StuffContext (DbContextOptions<StuffContext> options)
            : base(options)
        {
        }

        public DbSet<EFCRUDTest.Models.User> User { get; set; }
    }
}
