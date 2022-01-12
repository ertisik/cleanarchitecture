using MediatR;
using System;

namespace TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate
{
    public class ToDoListByDateQuery : IRequest<ToDoListDto>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
