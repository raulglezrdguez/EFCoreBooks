using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBooks.Entities.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //builder.Property(f => f.Title).HasMaxLength(150);
            builder.Property(f => f.PremiereDate).HasColumnType("date");
        }
    }
}

