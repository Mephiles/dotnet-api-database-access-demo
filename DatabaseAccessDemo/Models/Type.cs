using System;
using System.Collections.Generic;

namespace DatabaseAccessDemo.Models;

public partial class Type
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
