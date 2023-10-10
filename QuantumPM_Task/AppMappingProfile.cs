using AutoMapper;
using QuantumPM_Task.Domain.Entities;
using QuantumPM_Task.Models;

namespace QuantumPM_Task
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<NoteEntity, NoteCreate>().ReverseMap();
            CreateMap<NoteEntity, NoteModel > ().ReverseMap();
            CreateMap<NoteEntity, NoteEdit>().ReverseMap();
        }
    }
}
