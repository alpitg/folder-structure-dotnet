using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class LoginAudit
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime LoginTime { get; set; }
        public string RemoteIp { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Provider { get; set; } = null!;
        public string Latitude { get; set; } = null!;
        public string Longitude { get; set; } = null!;
    }
}
