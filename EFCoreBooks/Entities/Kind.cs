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
	}
}

