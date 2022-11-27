using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi.APIs
{
    public static class ProfileAPI
    {
        public static void MapUserRoutes(this IEndpointRouteBuilder app)
        {
            // GET All
            app.MapGet("/profile", async (MoviesContext db) =>
                await db.Profiles.ToListAsync())
                .WithTags("Profile");

            // GET By Id
            app.MapGet("/profile/{id}", async (int id, MoviesContext db) =>
                await db.Profiles.FindAsync(id)
                    is Profile entProfile
                        ? Results.Ok(entProfile)
                        : Results.NotFound())
                .WithTags("Profile");

            // POST Movies
            app.MapPost("/profile", async (Profile inputProfile, MoviesContext db) =>
            {
                db.Profiles.Add(inputProfile);
                await db.SaveChangesAsync();

                return Results.Created($"/profile/{inputProfile.Id}", inputProfile);
            }).WithTags("Profile");

            // PUT
            app.MapPut("/profile/{id}", async (int id, Profile inputProfile, MoviesContext db) =>
            {
                var entProfile = await db.Profiles.FindAsync(id);

                if (entProfile is null) return Results.NotFound();

                entProfile = inputProfile;

                await db.SaveChangesAsync();

                return Results.NoContent();
            }).WithTags("Profile");

            // DELETE
            app.MapDelete("/profile/{id}", async (int id, MoviesContext db) =>
            {
                if (await db.Profiles.FindAsync(id) is Profile entProfile)
                {
                    db.Profiles.Remove(entProfile);
                    await db.SaveChangesAsync();
                    return Results.Ok(entProfile);
                }

                return Results.NotFound();
            }).WithTags("Profile");
        }
    }
}
