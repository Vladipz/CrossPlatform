using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Endpoints
{
    public static class BooksApi
    {
        public static void MapBooksEndpoints(this IEndpointRouteBuilder app)
        {
            // GET all books
            _ = app.MapGet("/api/books", async (SpecialistBookshopDbContext context) =>
            {
                var books = await context.Books
                    .Include(b => b.Author)
                    .Include(b => b.BookCategory)
                    .ToListAsync();
                return Results.Ok(books);
            })
            .WithName("GetBooks");

            // GET book by id
            _ = app.MapGet("/api/books/{id}", async (int id, SpecialistBookshopDbContext context) =>
            {
                var book = await context.Books
                    .Include(b => b.Author)
                    .Include(b => b.BookCategory)
                    .FirstOrDefaultAsync(m => m.BookId == id);

                if (book == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(book);
            })
            .WithName("GetBookById");
        }

    }
}
