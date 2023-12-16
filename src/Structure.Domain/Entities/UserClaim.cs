﻿using System;
using System.Collections.Generic;

namespace Structure.Domain.Entities;

public partial class UserClaim
{
    public int Id { get; set; }

    public Guid ActionId { get; set; }

    public Guid UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual Action Action { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
