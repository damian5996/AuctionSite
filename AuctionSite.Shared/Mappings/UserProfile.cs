using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using AutoMapper;

namespace AuctionSite.Shared.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<TokenDto, TokenViewModel>();
        }
    }
}
