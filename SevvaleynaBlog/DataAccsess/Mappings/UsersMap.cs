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
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(50);

            builder.Property(x => x.Email).HasMaxLength(150);

            builder.Property(x => x.Password).HasMaxLength(100);

            builder.Property(x => x.Twitter).HasMaxLength(100);

            builder.Property(x => x.FullAdress).HasMaxLength(250);

            builder.Property(x => x.Instagram).HasMaxLength(100);

            builder.Property(x => x.Linkedin).HasMaxLength(100);

            builder.Property(x => x.Github).HasMaxLength(100);

            builder.Property(x => x.Phone).HasMaxLength(15);

            // Çok'a tek ilişki -many to one => Her kullanıcının birden çok bloğu olacak demektir

            builder.HasMany(x => x.Blogs).WithOne(x => x.Users).HasForeignKey(x => x.UserId);

            builder.ToTable("Users");



        }
    }
}
