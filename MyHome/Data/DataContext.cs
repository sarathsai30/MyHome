using Microsoft.EntityFrameworkCore;
using MyHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
