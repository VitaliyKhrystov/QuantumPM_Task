using AutoMapper;
using Microsoft.AspNetCore.Components;
using QuantumPM_Task.Domain.Entities;
using QuantumPM_Task.Domain.Repository.Abstract;
using QuantumPM_Task.Models;

namespace QuantumPM_Task.Pages
{
    public partial class CreateNote
    {
        [Inject] private IConfiguration Config { get; set; }
        [Inject] private INoteRepository NoteRepository { get; set; }
        [Inject] private IMapper Mapper { get; set; }
        [Inject] private ILogger<CreateNote> Logger { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        private int TitleCounter { get; set; } = 0;
        private int maxTitleLength;
        private int ContentCounter { get; set; } = 0;
        private int maxContentLength;
        private NoteCreate newNote;

        protected override void OnInitialized()
        {
            int.TryParse(Config.GetSection("maxTitleLength").Value, out int titleLength);
            maxTitleLength = titleLength > 0 ? titleLength : 100;

            int.TryParse(Config.GetSection("maxContentLength").Value, out int contentLength);
            maxContentLength = contentLength > 0 ? contentLength : 2000;

            newNote = new();
        }
        public void GetLength(ChangeEventArgs e, string name)
        {
            if (e.Value.ToString() != null && name == "title")
                TitleCounter = e.Value.ToString().Length;
            else
                ContentCounter = e.Value.ToString().Length;
        }

       public async Task AddNote()
        {
            try
            {
                await NoteRepository.CreateNoteAsync(Mapper.Map<NoteEntity>(newNote));
                Navigation.NavigateTo("/");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            
        }
    }
}
