using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesSharingApp.Data;
using NotesSharingApp.Models;
using NotesSharingApp.Models.Entities;

namespace NotesSharingApp.Controllers
{
       //localhost:xxxx/api/notes
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public NotesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllNotes()
        {
            var allNotes = dbContext.Notes.ToList();

            return Ok(allNotes);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetNoteById(Guid id)
        {
            var note = dbContext.Notes.Find(id);

            if(note is null) 
            {
                return NotFound();
            }
            return Ok(note);

        }

        [HttpPost]
        public IActionResult AddNote(AddNoteDto addNoteDto)
        {
            var noteEntity = new Note()
            {
                Title = addNoteDto.Title,
                NoteBody = addNoteDto.NoteBody,
                CreatedAt = DateTime.UtcNow // czas teraz
            };


            dbContext.Notes.Add(noteEntity);
            dbContext.SaveChanges();

            return Ok(noteEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateNote(Guid id, UpdateNoteDto updateNoteDto)
        {
            var note = dbContext.Notes.Find(id);

            if (note is null)
            {
                return NotFound();
            }

            note.Title = updateNoteDto.Title;
            note.NoteBody = updateNoteDto.NoteBody;
            dbContext.SaveChanges();
            return Ok(note);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteNote(Guid id)
        {
            var note = dbContext.Notes.Find(id);

            if( note is null)
            {
                return NotFound();
            }

            dbContext.Notes.Remove(note);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
