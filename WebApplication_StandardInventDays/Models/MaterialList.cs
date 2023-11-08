using System;
using System.Collections.Generic;

namespace WebApplication_StandardInventDays.Models;

public partial class MaterialList
{
    public string IdMatList { get; set; } = null!;

    public string? Fac { get; set; }

    public string? ItemNo { get; set; }

    public string? ItemDesc { get; set; }

    public string? UoM { get; set; }

    public virtual ICollection<Sid> Sids { get; set; } = new List<Sid>();
}
