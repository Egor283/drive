using System;
using System.Collections.Generic;

namespace Driver.Models;

public partial class History
{
    public int Id { get; set; }

    public int IdLicens { get; set; }

    public string OldStatus { get; set; } = null!;

    public string NewStatus { get; set; } = null!;

    public virtual Licen IdLicensNavigation { get; set; } = null!;
}
