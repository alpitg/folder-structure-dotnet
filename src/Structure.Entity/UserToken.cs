using System;
using System.Collections.Generic;

namespace Structure.Entity
{
    public partial class UserToken
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Value { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
