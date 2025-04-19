using System;
using System.Collections.Generic;

namespace Driver.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusDes { get; set; } = null!;

    public virtual ICollection<Licen> Licens { get; set; } = new List<Licen>();
}
