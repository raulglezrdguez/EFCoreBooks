using System;
namespace EFCoreBooks.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public bool ThumbUp { get; set; }
		// para la relacion uno a varios con la tabla Book:
		// BookId es la llave foranea al campo Id de la tabla Book
		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
	}
}

