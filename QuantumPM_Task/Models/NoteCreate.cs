using System.ComponentModel.DataAnnotations;

namespace QuantumPM_Task.Models
{
    public class NoteCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

    }
}
