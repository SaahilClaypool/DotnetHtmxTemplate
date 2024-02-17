using Microsoft.EntityFrameworkCore;

namespace AppTemplate.Controllers;

public class NotesController(AppDb db) : AppController
{
    public async Task<IActionResult> Index() =>
        View(await db.Notes.ToListAsync());

    public async Task<IActionResult> Edit(int id)
    {
        var note = await db.Notes.FindAsync(id);
        if (Hx())
            return Modal("_note", note!);
        return View("_note", note);
    }

    public async Task<IActionResult> Create([FromForm] NoteInput input)
    {
        var note = new Note(input.Title, input.Text, false);
        db.Add(note);
        await db.SaveChangesAsync();
        return PartialView("_viewNote", note);
    }

    public async Task<IActionResult> Update([FromForm] NoteInput input)
    {
        var note = await db.Notes.FindAsync(input.Id);
        note!.Title = input.Title;
        note!.Text = input.Text;
        await db.SaveChangesAsync();
        return PartialView("_viewNote", note);
    }
}

public record NoteInput(string Title, string Text)
{
    public int? Id { get; set; }
}
