namespace AuctionSite.BL.Common
{
    public interface IValidator<in TParam>
    {
        void Validate(TParam param);
    }
}
