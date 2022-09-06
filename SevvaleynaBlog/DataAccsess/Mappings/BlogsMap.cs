using DataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Mappings
{
    public class BlogsMap : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Images).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.BlogDateTime).HasMaxLength(150);

            // Tek' e çok ilişki One To Many
            builder.HasOne(x => x.Users).WithMany(x => x.Blogs).HasForeignKey(x => x.UserId);

            //Çok'a tek ilişki Many To One
            builder.HasMany(x => x.Comments).WithOne(x => x.Blogs).HasForeignKey(x => x.BlogsId);

            //Çok'a tek ilişki Many To One
            builder.HasMany(x => x.Interactions).WithOne(x => x.Blogs).HasForeignKey(x => x.BlogsId);

            builder.ToTable("Blogs");

        }
    }
}
