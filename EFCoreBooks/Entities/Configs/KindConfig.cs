using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBooks.Entities.Configs
{
	public class KindConfig: IEntityTypeConfiguration<Kind>
	{

        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            // para adicionar datos usando migrations
            var animation = new Kind { Id = 5, Name = "Animation" };
            var fantastic = new Kind { Id = 6, Name = "Fantastic" };
            builder.HasData(animation, fantastic);
        }
    }
}

