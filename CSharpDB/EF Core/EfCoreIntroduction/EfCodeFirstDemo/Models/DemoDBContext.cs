using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCodeFirstDemo.Models
{
    public class DemoDBContext : DbContext
    {
        public DemoDBContext()
        {

        }

        public DemoDBContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=EfCodeFirstDemo;Integrated Security=true;");
            }
        }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
