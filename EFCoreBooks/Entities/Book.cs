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

        // para la relacion con el kind
        // un book puede ser de varios kinds
        // cuando esta relacion esta en las dos tablas,
        // ef crea una tabla intermedia con los dos campos id de las dos tablas
        public HashSet<Kind> Kinds { get; set; } = new HashSet<Kind>();

        // relacion con la tabla bookauthor
        public List<BookAuthor> BooksAuthors { get; set; } = new List<BookAuthor>();

    }
}

