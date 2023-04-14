using System;
namespace EFCoreBooks.Entities
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public decimal Fortune { get; set; }
		public DateTime BirthDate { get; set; }
	}
}

