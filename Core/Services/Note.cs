namespace Core;

public class Note(string title, string text, bool complete) : BaseEntity
{
    public string Title { get; set; } = title;
    public string Text { get; set; } = text;
    public bool Complete { get; set; } = complete;
}
