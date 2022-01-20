using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public class CreateToDoCommandHandler :
        IRequestHandler<CreateToDoCommand, CreateToDoCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IToDoRepository toDoRepository;

        public CreateToDoCommandHandler(IMapper mapper,
            IToDoRepository toDoRepository)
        {
            this.mapper = mapper;
            this.toDoRepository = toDoRepository;
        }

        public async Task<CreateToDoCommandResponse> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            CreateToDoCommandResponse response = new CreateToDoCommandResponse();

            // validation here..

            var todoItem = mapper.Map<ToDo>(request);
            todoItem = await toDoRepository.AddAsync(todoItem);

            return response;
        }
    }
}
