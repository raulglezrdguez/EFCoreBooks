using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBooks.Entities
{
	public class Kind
	{
		//[Key]
		public int Id { get; set; }
		//[StringLength(maximumLength:150)]
		public string Name { get; set; } = null!;

		// un kind puede tener varios libros,
		// o sea hay varios libros que son de este tipo
		// cuando esta relacion esta en las dos tablas,
		// ef crea una tabla intermedia con los dos campos id de las dos tablas
		public HashSet<Book> Books { get; set; } = new HashSet<Book>();
	}
}

