using System;

namespace TaskManagement.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
