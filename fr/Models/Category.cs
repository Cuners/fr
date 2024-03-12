using System;
using System.Collections.Generic;

namespace fr.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CtegoryName { get; set; } = null!;

    public virtual ICollection<User> UserCategory1Navigations { get; set; } = new List<User>();

    public virtual ICollection<User> UserCategory2Navigations { get; set; } = new List<User>();

    public virtual ICollection<User> UserCategory3Navigations { get; set; } = new List<User>();
}
