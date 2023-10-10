using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuantumPM_Task.Domain.Entities;

namespace QuantumPM_Task.Domain.Repository.Abstract
{
    public interface INoteRepository
    {
        Task CreateNoteAsync(NoteEntity note);
        Task UpdateNoteAsync(NoteEntity note);
        Task<NoteEntity> GetNoteByIdAsync(Guid id);
        Task<IEnumerable<NoteEntity>> GetAllNotesAsync();
        Task DeleteNoteAsync(NoteEntity note);
    }
}
