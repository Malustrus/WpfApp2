using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public partial class Info
{
    public int Fauf { get; set; }

    public int Boat { get; set; }

    public int Position { get; set; }

    public string? SerialNumber { get; set; }

    public virtual ICollection<Charge> Charges { get; } = new List<Charge>();
}
