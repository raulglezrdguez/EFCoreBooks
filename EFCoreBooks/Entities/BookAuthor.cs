using System;
namespace EFCoreBooks.Entities
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public string Character { get; set; } = null!;
        public int Order { get; set; }

    }
}

