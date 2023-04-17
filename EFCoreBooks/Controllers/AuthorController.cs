using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBooks.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorController : ControllerBase
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

        [HttpGet("name_fortune")]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            // con mapeo manual entre Autor y AuthorDTO
            //return await context.Autors.Select(a => new AuthorDTO
            //{
            //    Name = a.Name,
            //    Fortune = a.Fortune
            //}).ToListAsync();

            // con mapeo automatico con automapper
            return await context.Autors.ProjectTo<AuthorDTO>(mapper.ConfigurationProvider).ToListAsync(); 
            
        }
    }


}

