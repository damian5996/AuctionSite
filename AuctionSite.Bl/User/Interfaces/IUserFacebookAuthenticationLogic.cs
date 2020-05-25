using AuctionSite.BL.Common;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.ViewModel;

namespace AuctionSite.BL.User.Interfaces
{
    public interface IUserFacebookAuthenticationLogic : IBusinessLogic<FacebookLoginBindingModel, TokenViewModel>
    {
    }
}
