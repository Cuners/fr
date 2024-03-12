using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly RegistrationDate { get; set; }

    public int? OrdersComplited { get; set; }

    public int? OrdersCreated { get; set; }

    public DateOnly? BirthDay { get; set; }

    public string? Description { get; set; }

    public byte[]? Photo { get; set; }

    public int? Category1 { get; set; }

    public int? Category2 { get; set; }

    public int? Category3 { get; set; }

    public virtual Category? Category1Navigation { get; set; }

    public virtual Category? Category2Navigation { get; set; }

    public virtual Category? Category3Navigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual ICollection<Proposal> Proposals { get; set; } = new List<Proposal>();
}
