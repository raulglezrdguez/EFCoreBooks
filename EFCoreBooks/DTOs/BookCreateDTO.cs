using System;
namespace EFCoreBooks.DTOs
{
	public class BookCreateDTO
	{
        public string Title { get; set; } = null!;
        public bool OnSale { get; set; }
        public double Price { get; set; }
        public DateTime PremiereDate { get; set; }
        public List<int> Kinds { get; set; } = new List<int>();
        public List<BookAuthorCreateDTO> BooksAuthors { get; set; } = new List<BookAuthorCreateDTO>();

    }
}

