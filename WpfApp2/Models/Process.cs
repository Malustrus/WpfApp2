using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public partial class Process
{
    public int ProcessId { get; set; }

    public int Fauf { get; set; }

    public int Boat { get; set; }

    public int? Status { get; set; }

    public DateTime? DateFin { get; set; }

    public string? Stand { get; set; }

    public string? Version { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
