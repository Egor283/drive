using System;
using System.Collections.Generic;

namespace Driver.Models;

public partial class Licen
{
    public int Id { get; set; }

    public DateTime LicenceDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public string Catergory { get; set; } = null!;

    public string LicenceSeries { get; set; } = null!;

    public int StatusId { get; set; }

    public int DriverId { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Status Status { get; set; } = null!;
}
