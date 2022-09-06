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
    public class InteractionsMap : IEntityTypeConfiguration<Interaction>
    {
        public void Configure(EntityTypeBuilder<Interaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IpAddress).HasMaxLength(20);

            builder.HasOne(x => x.Blogs).WithMany(x => x.Interactions).HasForeignKey(x => x.BlogsId);

            builder.ToTable("Interaction");
        }
    }
}
