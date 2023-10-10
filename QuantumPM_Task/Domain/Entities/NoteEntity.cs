using System.ComponentModel.DataAnnotations;

namespace QuantumPM_Task.Domain.Entities
{
    public class NoteEntity
    { 
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }
}
