using System;
namespace EFCoreBooks.DTOs
{
	public class CommentCreateDTO
	{
        public string? Content { get; set; }
        public bool ThumbUp { get; set; }
    }
}

