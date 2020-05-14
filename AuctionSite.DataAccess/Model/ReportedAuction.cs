using AuctionSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.DataAccess.Model
{
    public class ReportedAuction
    {
        public long Id { get; set; }
        public TypeEnum Type { get; set; } //?
        public string Description { get; set; }
        public ReportStatusEnum Status { get; set; }

    }
}
