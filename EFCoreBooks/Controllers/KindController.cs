using System;
using AutoMapper;
using EFCoreBooks.Data;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;
using Microsoft.AspNetCore.Mvc;

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
	}
}

