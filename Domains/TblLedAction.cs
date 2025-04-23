using System;
using System.Collections.Generic;

namespace EspTest3.Models;

public partial class TblLedAction
{
    public int LedActionId { get; set; }

    public int ActionId { get; set; }

    public int LedId { get; set; }

    public DateTime Time { get; set; }

    public virtual TblAction Action { get; set; } = null!;

    public virtual TblLed Led { get; set; } = null!;
}
