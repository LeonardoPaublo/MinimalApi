using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.APIs
{
    public static class ContentAPI
    {
        public static void MapContentRoutes(this IEndpointRouteBuilder app)
        {
            // GET All Movies
            app.MapGet("/content", async (MoviesContext db) =>
            {
                var result = await db.Contents.ToListAsync();
                return Results.Json(result);
           }).WithTags("Content");

            // GET By Id
            app.MapGet("/content/{id}", async (int id, MoviesContext db) =>
                await db.Contents.FindAsync(id)
                    is Content todo
                        ? Results.Ok(todo)
                        : Results.NotFound())
                .WithTags("Content");

            // POST Movies
            app.MapPost("/content", async (Content todo, MoviesContext db) =>
            {
                db.Contents.Add(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/content/{todo.Id}", todo);
            }).WithTags("Content");

            // PUT
            app.MapPut("/content/{id}", async (int id, Content inputTodo, MoviesContext db) =>
            {
                var todo = await db.Contents.FindAsync(id);

                if (todo is null) return Results.NotFound();

                todo.Title = inputTodo.Title;

                await db.SaveChangesAsync();

                return Results.NoContent();
            }).WithTags("Content");

            // DELETE
            app.MapDelete("/content/{id}", async (int id, MoviesContext db) =>
            {
                if (await db.Contents.FindAsync(id) is Content todo)
                {
                    db.Contents.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.Ok(todo);
                }

                return Results.NotFound();
            }).WithTags("Content");
        }
    }
}