using System;
using System.Collections.Generic;

namespace EspTest3.Models;

public partial class TblLed
{
    public int LedId { get; set; }

    public string? LedColour { get; set; } = null!;

    public virtual ICollection<TblLedAction> TblLedActions { get; set; } = new List<TblLedAction>();
}
