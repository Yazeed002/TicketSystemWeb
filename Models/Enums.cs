using System;
using System.Collections.Generic;
using System.Text;

namespace TicketSystem.Models
{
    public enum TicketSupportStatus
    {
        Open = 1,
        Pending,
        Canceled,
        Closed,
    }
    

    public enum TicketSupportLevel
    {
        Level1 = 1,
        Level2,
        Level3
    }
}
