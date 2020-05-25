using AuctionSite.BL.Common;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using System.Threading.Tasks;

namespace AuctionSite.BL.User.Interfaces
{
    public interface IRegisterUserLogic : IBusinessLogic<RegisterUserBindingModel, long>
    {
    }
}