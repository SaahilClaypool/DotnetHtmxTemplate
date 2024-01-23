using Microsoft.EntityFrameworkCore;

namespace AppTemplate.Controllers;

public class NotesController(AppDb db) : AppController
{
    public async Task<IActionResult> Index() =>
        View(await db.Notes.ToListAsync());

    public async Task<IActionResult> Edit(string id)
    {
        var guid = Guid.Parse(id);
        var note = await db.Notes.FindAsync(guid);
        if (Hx())
            return Modal("_note", note!);
        return View("_note", note);
    }

    public async Task<IActionResult> Create([FromForm] NoteInput input)
    {
        db.Add(new Note(input.Title, input.Text, false));
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update([FromForm] NoteInput input)
    {
        var note = await db.Notes.FindAsync(input.Id);
        note!.Title = input.Title;
        note!.Text = input.Text;
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
public record NoteInput(string Title, string Text)
{
    public Guid? Id { get; set;  }
}
