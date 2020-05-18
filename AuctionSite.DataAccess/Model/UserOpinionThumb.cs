namespace AuctionSite.DataAccess.Model
{
    public class UserOpinionThumb
    {
        public long UserId { get; set; }
        public long OpinionId { get; set; }
        public bool IsPositive { get; set; }

        public virtual User User { get; set; }
        public virtual Opinion Opinion { get; set; }
    }
}
