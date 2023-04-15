using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBooks.DTOs
{
	public class AuthorCreateDTO
	{
		[StringLength(150)]
		public string Name { get; set; } = null!;
		public decimal Fortune { get; set; }
		public DateTime BirthDate { get; set; }
	}
}

