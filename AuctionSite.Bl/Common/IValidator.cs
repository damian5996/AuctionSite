namespace AuctionSite.BL.Common
{
    internal interface IValidator<in TParam>
    {
        void Validate(TParam param);
    }
}
