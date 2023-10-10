using System.Xml.Linq;
using System;

namespace QuantumPM_Task.Models
{
    public class NoteModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
