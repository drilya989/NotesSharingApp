using Microsoft.EntityFrameworkCore;
using NotesSharingApp.Models.Entities;

namespace NotesSharingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
