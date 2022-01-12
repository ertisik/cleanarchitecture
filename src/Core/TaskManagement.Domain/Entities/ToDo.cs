using System;
using TaskManagement.Domain.Common;

namespace TaskManagement.Domain.Entities
{
    public class ToDo : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Task { get; set; }
        public int Priority { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime? Completed { get; set; }
    }
}
