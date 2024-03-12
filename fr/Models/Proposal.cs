using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class Proposal
{
    public int ProposalId { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public DateOnly CreationDate { get; set; }

    public int Status { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProposalStatus StatusNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
