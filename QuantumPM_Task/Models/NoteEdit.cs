using System.ComponentModel.DataAnnotations;

namespace QuantumPM_Task.Models
{
    public class NoteEdit
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
