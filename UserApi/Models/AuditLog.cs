using System;
using UserApi.Models;

namespace UserApi.Models
{

    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}