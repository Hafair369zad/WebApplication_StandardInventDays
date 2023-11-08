using System;
using System.Collections.Generic;

namespace WebApplication_StandardInventDays.Models;

public partial class Sid
{
    public string IdSid { get; set; } = null!;

    public string IdMatList { get; set; } = null!;

    public string Fac { get; set; } = null!;

    public string ItemNo { get; set; } = null!;

    public string? ItemDesc { get; set; }

    public string? UoM { get; set; }

    public string? VendorType { get; set; }

    public string? ProdLt { get; set; }

    public string MonthlyConsume { get; set; } = null!;

    public string? SupplyCapacity { get; set; }

    public string? CapacityDifferent { get; set; }

    public string? DeliveryCycle { get; set; }

    public string? Consumption { get; set; }

    public string? Reject { get; set; }

    public string? MoQ { get; set; }

    public double? Hasil { get; set; }

    public string? Remark { get; set; }

    public virtual MaterialList IdMatListNavigation { get; set; } = null!;
}
