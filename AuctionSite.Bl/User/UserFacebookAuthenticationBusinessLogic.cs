using System;
using AuctionSite.BL.Common;
using AuctionSite.BL.User.Interface;
using AuctionSite.DataAccess;
using AuctionSite.DataAccess.Repositories.Interfaces;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionSite.BL.User
{
    public class UserFacebookAuthenticationBusinessLogic : BaseBusinessLogic<FacebookLoginBindingModel, TokenDto, TokenViewModel>, IUserFacebookAuthenticationBusinessLogic
    {
        private readonly IFacebookApiRepository _facebookApiRepository;

        public UserFacebookAuthenticationBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserFacebookAuthenticationBusinessLogic> logger,
            IFacebookApiRepository facebookApiRepository) : base(unitOfWork, mapper, logger)
        {
            _facebookApiRepository = facebookApiRepository;
        }

        protected override IEnumerable<IValidator<FacebookLoginBindingModel>> Validators =>
            Enumerable.Empty<IValidator<FacebookLoginBindingModel>>();
        protected override async Task<TokenDto> ExecutionAsync(FacebookLoginBindingModel parameter)
        {
            var isTokenValid = await _facebookApiRepository.ValidateToken(parameter.Token);

            if (!isTokenValid)
            {
                throw new UnauthorizedAccessException();
            }

            return new TokenDto();
        }
    }
}
