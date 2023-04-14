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
	}
}

