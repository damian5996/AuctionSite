using AuctionSite.Shared.Enums;
using Type = AuctionSite.Shared.Enums.Type;

namespace AuctionSite.DataAccess.Model
{
    public class ReportedAuction
    {
        public long Id { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }

        public long ReporterId { get; set; }
        public long AuctionId { get; set; }
        public virtual User Reporter { get; set; }
        public virtual Auction Auction { get; set; }
    }
}
