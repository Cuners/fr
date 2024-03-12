using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Budget { get; set; }

    public DateOnly? CreationDate { get; set; }

    public int? Status { get; set; }

    public int? Category1 { get; set; }

    public int? Category2 { get; set; }

    public int? Category3 { get; set; }

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();

    public virtual OrderStatus? StatusNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
