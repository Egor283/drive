﻿using System;
using System.Collections.Generic;

namespace Driver.Models;

public partial class Photo
{
    public int Id { get; set; }

    public byte[] Photo1 { get; set; } = null!;

    public virtual Driver? Driver { get; set; }
}
