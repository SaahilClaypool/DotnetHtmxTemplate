using Microsoft.EntityFrameworkCore;

namespace Core;

public class AppDb : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public string DbPath { get; }

    public AppDb()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "app.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
}
