using Microsoft.AspNetCore.Components;
using QuantumPM_Task.Models;

namespace QuantumPM_Task.Shared
{
    public partial class Note
    {
        [Parameter]
        public NoteModel CurrentNote { get; set; }
        private bool isHide = true;

        string GetDate(DateTime date, string text)
        {
            if (DateTime.Now.Date == date.Date)
            {
                return $"{text} today";
            }
            else if (DateTime.Now.Date > date.Date)
            {
                var numberOfDays = DateTime.Now.Date - date.Date;
                var day = numberOfDays.TotalDays == 1 ? "day" : "days";
                return $"{text} {numberOfDays.Days} {day} ago";
            }
            else
            {
                return $"Curent date cannot be lower than {text} date";
            }
        }
    }
}
