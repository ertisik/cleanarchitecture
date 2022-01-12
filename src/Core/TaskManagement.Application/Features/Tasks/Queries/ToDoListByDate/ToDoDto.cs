using System;

namespace TaskManagement.Application.Features.Tasks.Queries.ToDoListByDate
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public int Priority { get; set; }
        public DateTime Created { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime? Completed { get; set; }
    }
}
