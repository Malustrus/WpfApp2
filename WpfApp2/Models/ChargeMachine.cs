using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public partial class ChargeMachine
{
    public int ProcessId { get; set; }

    public int Position { get; set; }

    public string Type { get; set; } = null!;

    public string? Charge { get; set; }

    public virtual Result P { get; set; } = null!;
}
