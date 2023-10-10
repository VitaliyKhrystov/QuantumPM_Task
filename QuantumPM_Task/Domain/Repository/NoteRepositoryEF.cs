using Microsoft.EntityFrameworkCore;
using QuantumPM_Task.Domain.Entities;
using QuantumPM_Task.Domain.Repository.Abstract;

namespace QuantumPM_Task.Domain.Repository
{
    public class NoteRepositoryEF : INoteRepository, IDisposable
    {
        private readonly AppDbContext dbContext;
        private bool disposed = false;

        public NoteRepositoryEF(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateNoteAsync(NoteEntity note)
        {
            await dbContext.AddAsync(note);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteEntity>> GetAllNotesAsync()
        {
            return await dbContext.Notes.AsNoTracking().ToListAsync();
        }

        public async Task<NoteEntity> GetNoteByIdAsync(Guid id)
        {
            return await dbContext.Notes.FirstOrDefaultAsync(n => n.Id == id, default);
        }

        public async Task UpdateNoteAsync(NoteEntity note)
        {
            dbContext.Notes.Update(note);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(NoteEntity note)
        {
            dbContext.Notes.Remove(note);
            await dbContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.DisposeAsync();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
