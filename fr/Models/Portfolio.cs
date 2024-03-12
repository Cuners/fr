using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class Portfolio
{
    public int PortfolioId { get; set; }

    public int UserId { get; set; }

    public byte[] Image { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Link { get; set; }

    public virtual User User { get; set; } = null!;
}
