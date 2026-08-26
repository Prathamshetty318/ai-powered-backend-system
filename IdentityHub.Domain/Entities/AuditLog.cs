using System;
using IdentityHub.Domain.Entities;

namespace IdentityHub.Domain.Entities
{

    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
