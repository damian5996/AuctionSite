using AuctionSite.DataAccess.Model;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using AutoMapper;

namespace AuctionSite.DataAccess.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<TokenDto, TokenViewModel>();
            CreateMap<RegisterUserBindingModel, UserDto>();
            CreateMap<User, UserDto>();
        }
    }
}
