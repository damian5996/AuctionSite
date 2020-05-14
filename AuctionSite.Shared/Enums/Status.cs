using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.Shared.Enums
{
    public enum Status
    {
        Unspecified = 0,
        Draft = 1,
        Active = 2,
        Closed = 3,
        Sold = 4,
        Overdue = 5,
        Deleted = 6
    }
}
