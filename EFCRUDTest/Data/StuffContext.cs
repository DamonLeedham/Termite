using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCRUDTest.Models;

namespace EFCRUDTest.Models
{
    public class StuffContext : DbContext
    {
        public StuffContext (DbContextOptions<StuffContext> options)
            : base(options)
        {
        }

        public DbSet<EFCRUDTest.Models.User> User { get; set; }

        public DbSet<EFCRUDTest.Models.Bug> Bug { get; set; }
        public DbSet<EFCRUDTest.Models.BugType> BugType { get; set; }
        public DbSet<EFCRUDTest.Models.Project> Project { get; set; }
        public DbSet<EFCRUDTest.Models.Status> Status { get; set; }
    }
}
