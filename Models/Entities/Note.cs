namespace NotesSharingApp.Models.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string NoteBody { get; set; }

        //id usera, który dodał notatki

        //data dodanie notatki? 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
