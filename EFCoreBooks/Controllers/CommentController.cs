using System;
using AutoMapper;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBooks.Controllers
{
	[ApiController]
	[Route("api/v1/books/{bookId}/comments")]
	public class CommentController: ControllerBase
	{
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public CommentController(ApplicationDBContext context, IMapper mapper)
		{
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int bookId, CommentCreateDTO commentCreateDTO)
        {
            var comment = mapper.Map<Comment>(commentCreateDTO);
            comment.BookId = bookId;

            context.Add(comment);
            await context.SaveChangesAsync();

            return Ok();
        }
	}
}

