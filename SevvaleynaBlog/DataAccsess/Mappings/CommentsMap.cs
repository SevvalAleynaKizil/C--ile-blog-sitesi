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
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Commenter).HasMaxLength(100);
            builder.Property(x => x.CommentDate).HasColumnType("datetime");

            builder.HasOne(x => x.Blogs).WithMany(x => x.Comments).HasForeignKey(x => x.BlogsId);

            builder.ToTable("Comments");


        }
    }
}
