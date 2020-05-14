namespace AuctionSite.DataAccess.Model
{
    public class Bid
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public long Timestamp { get; set; }
        public long  UserId { get; set; }
        public long AuctionId { get; set; }

        public virtual User User { get; set; }
        public virtual Auction Auction { get; set; }
    }
}
