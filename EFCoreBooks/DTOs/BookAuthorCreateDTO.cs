using System;
namespace EFCoreBooks.DTOs
{
	public class BookAuthorCreateDTO
	{
		public int AuthorId { get; set; }
		public string Character { get; set; } = null!;
	}
}

