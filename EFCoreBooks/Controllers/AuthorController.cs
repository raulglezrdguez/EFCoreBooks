using System;
using AutoMapper;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreBooks.Controllers
{
	[ApiController]
	[Route("api/v1/authors")]
	public class AuthorController: ControllerBase
	{
		private readonly ApplicationDBContext context;
		private readonly IMapper mapper;

		public AuthorController(ApplicationDBContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		[HttpPost]
		public async Task<ActionResult> Post(AuthorCreateDTO authorCreate)
		{
			var author = mapper.Map<Author>(authorCreate);
			context.Add(author);
			await context.SaveChangesAsync();
			return Ok();
		}
	}


}

