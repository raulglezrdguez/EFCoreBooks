using System;
namespace EFCoreBooks.Entities
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public bool OnSale { get; set; }
		public double Price { get; set; }
		public DateTime PremiereDate { get; set; }
		// relacion con la tabla Comment
		// le decimos que hay varios comentarios relacionados con cada book
		// HashSet no devuelve los datos de forma ordenada
		public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();

	}
}

