using DataAccsess.Mappings;
using DataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete
{
    public class BlogContext : DbContext
    {
        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Interaction> Interaction { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2JCJJ20\SQLEXPRESS;Database=SevvaleynaBlog;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogsMap());
            modelBuilder.ApplyConfiguration(new CommentsMap());

            modelBuilder.ApplyConfiguration(new InteractionsMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
        }
    }
}
