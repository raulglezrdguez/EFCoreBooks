using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreBooks.DTOs
{
	public class KindCreateDTO
	{
		[StringLength(maximumLength: 150)]
		public string name { get; set; } = null!;
	}
}

