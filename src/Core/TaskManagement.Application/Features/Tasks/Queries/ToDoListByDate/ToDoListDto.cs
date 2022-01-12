using System.Collections.Generic;

namespace TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate
{
    public class ToDoListDto
    {
        public List<ToDoDto> Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
