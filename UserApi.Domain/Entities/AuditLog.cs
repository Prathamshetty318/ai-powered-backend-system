using System;
using UserApi.Domain.Entities;

namespace UserApi.Domain.Entities
{

    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}