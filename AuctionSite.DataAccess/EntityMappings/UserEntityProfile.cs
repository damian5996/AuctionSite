using AuctionSite.DataAccess.Model;
using AuctionSite.Shared.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.DataAccess.EntityMappings
{
    public class UserEntityProfile : Profile
    {
        public UserEntityProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
