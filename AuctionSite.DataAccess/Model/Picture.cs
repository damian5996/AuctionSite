namespace AuctionSite.DataAccess.Model
{
    public class Picture
    {
        public long Id { get; set; }
        public long AuctionId { get; set; }
        public string BlobName { get; set; }

        public virtual Auction Auction { get; set; }
    }
}
