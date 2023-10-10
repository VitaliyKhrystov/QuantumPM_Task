using Microsoft.EntityFrameworkCore;
using QuantumPM_Task.Domain.Entities;

namespace QuantumPM_Task.Domain
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public DbSet<NoteEntity> Notes { get; set; }
    }
}
