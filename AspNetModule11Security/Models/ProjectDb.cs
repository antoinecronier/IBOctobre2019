using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetModule11Security.Models
{
    public class ProjectDb : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ProjectDb() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasOptional(x => x.Project).WithMany(x => x.Comments);
            modelBuilder.Entity<Employee>().HasMany(x => x.Projects).WithMany(x => x.Employees);

            base.OnModelCreating(modelBuilder);
        }
    }
}