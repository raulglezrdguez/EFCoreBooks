using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreBooks.Entities.Configs
{
    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            // llave primaria compuesta: bookId y authorId
            builder.HasKey(ba => new { ba.BookId, ba.AuthorId });
        }
    }
}

