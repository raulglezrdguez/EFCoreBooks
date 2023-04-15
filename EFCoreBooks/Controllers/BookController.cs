using System;
using AutoMapper;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreBooks.Controllers
{
	[ApiController]
	[Route("api/v1/books")]
	public class BookController: ControllerBase
	{
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;
        private readonly ILogger<BookController> logger;

        public BookController(ApplicationDBContext context, IMapper mapper, ILogger<BookController> logger)
		{
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post(BookCreateDTO bookCreateDTO)
        {
            var book = mapper.Map<Book>(bookCreateDTO);

            // le digo que los datos que esta recibiendo
            // ya estan en la base de datos
            if (book.Kinds is not null)
            {
                foreach(var kind in book.Kinds)
                {
                    context.Entry(kind).State = EntityState.Unchanged;
                }
            }

            // le adiciono nuevos datos a los que me envia el cliente
            if (book.BooksAuthors is not null)
            {
                logger.LogInformation("book.BooksAuthors is not null");
                for (var i = 0; i < book.BooksAuthors.Count; i++)
                {
                    book.BooksAuthors[i].Order = i + 1;
                }
            }
            else
            {
                logger.LogInformation("book.BooksAuthors is null");
            }

            context.Add(book);

            await context.SaveChangesAsync();

            return Ok();
        }
	}
}

