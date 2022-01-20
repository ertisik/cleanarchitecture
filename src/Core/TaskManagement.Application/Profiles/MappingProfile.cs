using AutoMapper;
using TaskManagement.Application.Features.Tasks.Commands;
using TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<CreateToDoCommand, ToDo>();
        }
    }
}
