using MediatR;
using System;

namespace TaskManagement.Application.Features.Tasks.Commands
{
    public class CreateToDoCommand : IRequest<CreateToDoCommandResponse>
    {
        public string Task { get; set; }
        public int Priority { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
