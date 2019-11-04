using LessonEF6.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEF6.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> UserDb { get; set; }

        public AppDbContext() : base()
        {
            //// Drop create
            //if (this.Database.Exists())
            //{
            //    this.Database.Delete();
            //}
            //this.Database.Create();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasRequired<User>(x => x.From).WithMany(x => x.Comments);
            //modelBuilder.Entity<User>().HasMany<Comment>(x => x.Comments).WithRequired(x => x.From);
            modelBuilder.Entity<Comment>().HasOptional<User>(x => x.To);
            base.OnModelCreating(modelBuilder);
        }
    }
}
