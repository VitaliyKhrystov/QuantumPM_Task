using AutoMapper;
using Microsoft.AspNetCore.Components;
using QuantumPM_Task.Domain.Entities;
using QuantumPM_Task.Domain.Repository.Abstract;
using QuantumPM_Task.Models;

namespace QuantumPM_Task.Pages
{
    public partial class EditNote
    {
        [Parameter] public string NoteId { get; set; }
        [Inject] private IConfiguration Config { get; set; }
        [Inject] private INoteRepository NoteRepository { get; set; }
        [Inject] private IMapper Mapper { get; set; }
        [Inject] private ILogger<EditNote> Logger { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }


        private NoteEdit currentNote = new();
        private NoteEntity noteDB = new();
        private int TitleCounter { get; set; }
        private int maxTitleLength = default;
        private int ContentCounter { get; set; } = 0;
        private int maxContentLength = default;

        protected async override Task OnInitializedAsync()
        {
            try
            {
                noteDB = await NoteRepository.GetNoteByIdAsync(Guid.Parse(NoteId));
                currentNote = noteDB != null ? Mapper.Map<NoteEdit>(noteDB) : new NoteEdit() { Id = default, Title = "-", Content = "-", CreatedAt = default, UpdatedAt = default };

                TitleCounter = currentNote.Title.Length;
                ContentCounter = currentNote.Content.Length;

                int.TryParse(Config.GetSection("maxTitleLength").Value, out int titleLength);
                maxTitleLength = titleLength > 0 ? titleLength : 100;

                int.TryParse(Config.GetSection("maxContentLength").Value, out int contentLength);
                maxContentLength = contentLength > 0 ? contentLength : 2000;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
        }

       public async Task UpdateNote()
        {
            try
            {
                noteDB.Title = currentNote.Title;
                noteDB.Content = currentNote.Content;
                noteDB.UpdatedAt = DateTime.Now;
                await NoteRepository.UpdateNoteAsync(noteDB);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                Navigation.NavigateTo("/");
            }
        }

        public async Task DeleteNote()
        {
            try
            {
                await NoteRepository.DeleteNoteAsync(noteDB);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                Navigation.NavigateTo("/");
            }     
        }
    }
}
