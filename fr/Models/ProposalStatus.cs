using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class ProposalStatus
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
