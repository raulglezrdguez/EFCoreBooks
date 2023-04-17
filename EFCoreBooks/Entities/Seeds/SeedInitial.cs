using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBooks.Entities.Seeds
{
    public class SeedInitial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var autor1 = new Author()
            {
                Id = 2,
                Name = "Another author",
                BirthDate = new DateTime(1967, 2, 1),
                Fortune = 123
            };
            modelBuilder.Entity<Author>().HasData(autor1);

            var book1 = new Book()
            {
                Id = 5,
                Title = "Book five",
                OnSale = true,
                Price = 123.45,
                PremiereDate = new DateTime(2023, 1, 2)
            };
            modelBuilder.Entity<Book>().HasData(book1);

            var comment1 = new Comment()
            {
                Id = 3,
                Content = "Comment three",
                ThumbUp = true,
                BookId = book1.Id
            };
            modelBuilder.Entity<Comment>().HasData(comment1);

            // relacion muchos a muchos sin tabla intermedia
            // hay que utilizar los nombres de la tabla y las columnas
            // porque no existe una entidad intermedia
            var tableBookKind = "BookKind"; // el nombre de la tabla en la base de datos
            var fieldBookId = "BooksId"; // el nombre del campo en la base de datos
            var fieldKindId = "KindsId"; // el nombre del campo en la base de datos
            var comedy = 2; // el valor que tiene en la base de datos
            modelBuilder.Entity(tableBookKind).HasData(
                new Dictionary<string, object>
                {
                    [fieldBookId] = book1.Id,
                    [fieldKindId] = comedy
                }
            );

            // relacion muchos a muchos con la tabla intermedia
            var bookAuthor1 = new BookAuthor()
            {
                AuthorId = autor1.Id,
                BookId = book1.Id,
                Character = "Character one",
                Order = 1
            };
            modelBuilder.Entity<BookAuthor>().HasData(bookAuthor1);




        }
    }
}

