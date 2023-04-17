using System;
using AutoMapper;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBooks.Controllers
{
	[ApiController]
	[Route("api/v1/kinds")]
	public class KindController: ControllerBase
	{
		private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public KindController(ApplicationDBContext context, IMapper mapper)
		{
			this.context = context;
            this.mapper = mapper;
        }

		[HttpPost]
		public async Task<ActionResult> Post(KindCreateDTO kindCreate)
		{
			// forma manual de mappear
			//var kind = new Kind
			//{
			//	Name = kindCreate.name
			//};

			// mappear utilizando mapper
			var kind = mapper.Map<Kind>(kindCreate);

			// marco el kind para guardarlo en la base de datos
			context.Add(kind);
			// almaceno los cambios en la base de datos
			await context.SaveChangesAsync();
			// devuelvo Ok
			return Ok();
		}

		[HttpPost("many")]
		public async Task<ActionResult> Post(KindCreateDTO[] kindCreates)
		{
			var kinds = mapper.Map<Kind[]>(kindCreates);
			context.AddRange(kinds);
			await context.SaveChangesAsync();
			return Ok();
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Kind>>> Get()
		{
			return await context.Kinds.OrderBy(k => k.Name).ToListAsync();
		}

		[HttpGet("name")]
		public async Task<ActionResult<IEnumerable<Kind>>> Get(string name)
		{
			return await context.Kinds.Where(k => k.Name.Contains(name)).ToListAsync();
		}

		[HttpGet("id")]
		public async Task<ActionResult<Kind>> Get(int id)
		{
			var kind = await context.Kinds.FirstOrDefaultAsync(k => k.Id == id);
			if (kind is null)
			{
				return NotFound();
			}
			return kind;
		}

		[HttpPut("{id}/{name}")]
		public async Task<ActionResult> Put(int id, string name)
		{
			var kind =  context.Kinds.FirstOrDefault(k => k.Id == id);
			if (kind is null)
			{
				return NotFound();
			}

			kind.Name = name;
			await context.SaveChangesAsync();

			return Ok();
		}

        [HttpPut("{id}")]
        public async Task<ActionResult> PutDTO(int id, KindCreateDTO kindCreateDTO)
        {
			var kind = mapper.Map<Kind>(kindCreateDTO);
			kind.Id = id;

			context.Update(kind);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}

