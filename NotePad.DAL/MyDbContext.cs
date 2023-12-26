using Microsoft.EntityFrameworkCore;
using NotePad.Domain;

namespace NotePad.DAL;

public class MyDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<NoteEntity> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;password=1234;Database=test"); //ToDo: create connection string
    }
}