﻿using System;
namespace EFCoreBooks.Entities
{
	public class Comment
	{
		public int Id { get; set; }
		public string? Content { get; set; }
		public bool ThumbUp { get; set; }
	}
}

