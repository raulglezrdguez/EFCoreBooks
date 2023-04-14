using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EFCoreBooks.Entities.Configs
{
	public class AuthorConfig: IEntityTypeConfiguration<Author>
    {

        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //builder.Property(a => a.Name).HasMaxLength(150);
            builder.Property(a => a.BirthDate).HasColumnType("date");
            builder.Property(a => a.Fortune).HasPrecision(8, 2);

        }
    }
}

