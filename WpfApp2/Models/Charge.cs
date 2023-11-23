using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp2.Models;

public partial class Charge
{
    public int Id { get; set; }

    public int Fauf { get; set; }

    public int Boat { get; set; }

    public int Position { get; set; }

    public string? Charge1 { get; set; }

    public virtual Info Info { get; set; } = null!;

    public Charge()
    {
        
    }

    public Charge(ChargeMachine chargeMachine)
    {
        Charge1 = chargeMachine.Charge;
    }
}
