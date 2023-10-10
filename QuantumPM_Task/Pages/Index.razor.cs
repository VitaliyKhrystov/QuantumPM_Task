using AutoMapper;
using Microsoft.AspNetCore.Components;
using QuantumPM_Task.Domain.Repository.Abstract;
using QuantumPM_Task.Models;

namespace QuantumPM_Task.Pages
{
    public partial class Index
    {
        [Inject] INoteRepository NoteRepository { get; set; }
        [Inject] IMapper Mapper { get; set; }
        private int TotalNotes { get; set; }
        private List<NoteModel> AllNotesList { get; set; } = new();
        private List<NoteModel> NotesAfterSearch { get; set; } = new();


        protected async override Task OnInitializedAsync()
        {
            var notes = await NoteRepository.GetAllNotesAsync();
            AllNotesList = notes.Select(n => Mapper.Map<NoteModel>(n)).ToList();
            TotalNotes = AllNotesList.Count;
            NotesAfterSearch = AllNotesList;
        }

        public void SearchNote(ChangeEventArgs e)
        {
            var search = e.Value.ToString().ToLower();
            NotesAfterSearch = AllNotesList.Where(n => n.Title.ToLower().Contains(search) || n.Content.ToLower().Contains(search)).ToList();
            TotalNotes = NotesAfterSearch.Count;
        }

    }
}
