using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate
{
    public class ToDoListByDateQueryHandler :
        IRequestHandler<ToDoListByDateQuery, ToDoListDto>
    {
        private readonly IMapper mapper;
        private readonly IToDoRepository toDoRepository;

        public ToDoListByDateQueryHandler(IMapper mapper,
            IToDoRepository toDoRepository)
        {
            this.mapper = mapper;
            this.toDoRepository = toDoRepository;
        }

        public async Task<ToDoListDto> Handle(ToDoListByDateQuery request,
            CancellationToken cancellationToken)
        {
            ToDoListDto result = new ToDoListDto { Size = request.Size, Page = request.Page };

            var list = await toDoRepository.ToDoListByDate(request.Date, request.Page, request.Size);
            result.Items = mapper.Map<List<ToDoDto>>(list);
            
            result.Total = await toDoRepository.GetTotalCountOfToDoByDate(request.Date);

            return result;
        }
    }
}
