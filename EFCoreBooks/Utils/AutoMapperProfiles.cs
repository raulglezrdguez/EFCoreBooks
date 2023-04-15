using System;
using AutoMapper;
using EFCoreBooks.DTOs;
using EFCoreBooks.Entities;

namespace EFCoreBooks.Utils
{
	public class AutoMapperProfiles: Profile
	{
		public AutoMapperProfiles()
		{
            CreateMap<KindCreateDTO, Kind>();
            CreateMap<AuthorCreateDTO, Author>();

            CreateMap<BookCreateDTO, Book>()
                .ForMember(b => b.Kinds,
                    dto => dto.MapFrom(field => field.Kinds.Select(id => new Kind { Id = id })));

            CreateMap<BookAuthorCreateDTO, BookAuthor>();

            CreateMap<CommentCreateDTO, Comment>();

        }
    }
}

