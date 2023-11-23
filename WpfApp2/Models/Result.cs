using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public partial class Result
{
    public int ProcessId { get; set; }

    public int Position { get; set; }

    public int? Data1 { get; set; }

    public int? Data2 { get; set; }

    public int? Data3 { get; set; }

    public virtual ICollection<ChargeMachine> ChargeMachines { get; } = new List<ChargeMachine>();

    public virtual Process Process { get; set; } = null!;
}
