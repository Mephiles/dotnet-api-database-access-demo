using System;
using System.Collections.Generic;

namespace DatabaseAccessDemo.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual Type TypeNavigation { get; set; } = null!;
}
