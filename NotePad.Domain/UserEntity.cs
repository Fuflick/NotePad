namespace NotePad.Domain;

public class UserEntity
{
    public required string Id { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public List<NoteEntity>? Notes { get; set; }

}