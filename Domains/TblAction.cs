using System;
using System.Collections.Generic;

namespace EspTest3.Models;

public partial class TblAction
{
    public int ActionId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TblLedAction> TblLedActions { get; set; } = new List<TblLedAction>();
}
