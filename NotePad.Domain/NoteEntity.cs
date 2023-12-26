using System.ComponentModel.DataAnnotations;

namespace NotePad.Domain;

public class NoteEntity
{
    [Key]
    public required string Id { get; set; }

    public required string UserId { get; set; }

    public string? Body { get; set; }

    public DateTime CreationDate { get; set; }

    public string? Name { get; set; }
}