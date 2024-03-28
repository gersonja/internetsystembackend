using System;
using System.Collections.Generic;

namespace InternetSystem.DBModels;

public partial class Payment
{
    public int Paymentid { get; set; }

    public DateTime Paymentdate { get; set; }

    public int Clientid { get; set; }

    public decimal Amount { get; set; }

    public int Contractid { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;
}
