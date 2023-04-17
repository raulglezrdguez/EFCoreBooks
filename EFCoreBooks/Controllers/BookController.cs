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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await context.Books
                .OrderBy(b => b.Title)
                    .ThenBy(b => b.Price)
                .ToListAsync();
        }

        [HttpGet("title_price")]
        public async Task<ActionResult> GetTitlePrice()
        {
            var books = await context.Books.Select(b => new { b.Title, b.Price }).ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            // busco los libros, incluyo los comments, kind and bookauthors
            // los booksauthors los ordeno por el field order,
            // e incluyo los authors de cada bookauthor
            // aqui obtengo los campos que hay en la tabla
            var book = context.Books
                .Include(b => b.Comments)
                .Include(b => b.Kinds)
                .Include(b => b.BooksAuthors.OrderBy(ba => ba.Order))
                    .ThenInclude(ba => ba.Author)
                .FirstOrDefault(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpGet("select/{id}")]
        public async Task<ActionResult> GetByIdSelect(int id)
        {
            // busco los libros, incluyo los comments, kind and bookauthors
            // los booksauthors los ordeno por el field order,
            // e incluyo los authors de cada bookauthor
            // aqui obtengo los campos que seleccione de la tabla
            var book = await context.Books
                .Select(b => new
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    Kinds = b.Kinds.Select(k => new
                    {
                        Name = k.Name
                    }).ToList(),
                    Authors = b.BooksAuthors.OrderBy(ba => ba.Order).Select(ba => new { ba.Author.Name }),
                    CommentsCount = b.Comments.Count(),
                })
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}

