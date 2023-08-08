using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ModelISAPI.Data;

namespace ModelISAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }


public static class NoteEndpoints
{
	public static void MapNoteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Note", async (ModelISAPIContext db) =>
        {
            return await db.Note.ToListAsync();
        })
        .WithName("GetAllNotes")
        .Produces<List<Note>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Note/{id}", async (int Id, ModelISAPIContext db) =>
        {
            return await db.Note.FindAsync(Id)
                is Note model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetNoteById")
        .Produces<Note>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Note/{id}", async (int Id, Note note, ModelISAPIContext db) =>
        {
            var foundModel = await db.Note.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(note);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateNote")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Note/", async (Note note, ModelISAPIContext db) =>
        {
            db.Note.Add(note);
            await db.SaveChangesAsync();
            return Results.Created($"/Notes/{note.Id}", note);
        })
        .WithName("CreateNote")
        .Produces<Note>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Note/{id}", async (int Id, ModelISAPIContext db) =>
        {
            if (await db.Note.FindAsync(Id) is Note note)
            {
                db.Note.Remove(note);
                await db.SaveChangesAsync();
                return Results.Ok(note);
            }

            return Results.NotFound();
        })
        .WithName("DeleteNote")
        .Produces<Note>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
