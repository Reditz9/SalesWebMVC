using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SWContext : DbContext
    {
        public SWContext(DbContextOptions<SWContext> options)
            : base(options)
        { }

        public DbSet<SalesWebMVC.Models.Department> Departments { get; set; } = default!;
    }
}
