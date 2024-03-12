using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class Profile
{
    public int ProfileId { get; set; }

    public int UserId { get; set; }

    public string? Description { get; set; }

    public byte[]? Photo { get; set; }

    public virtual User User { get; set; } = null!;
}
