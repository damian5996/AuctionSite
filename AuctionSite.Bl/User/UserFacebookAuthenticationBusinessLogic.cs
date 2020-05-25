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
using AuctionSite.BL.User.Internal;

namespace AuctionSite.BL.User
{
    public class UserFacebookAuthenticationBusinessLogic : BaseBusinessLogic<FacebookLoginBindingModel, TokenDto, TokenViewModel>, IUserFacebookAuthenticationBusinessLogic
    {
        private readonly IFacebookApiRepository _facebookApiRepository;
        private readonly GetUserByEmail _getUserByEmail;

        public UserFacebookAuthenticationBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserFacebookAuthenticationBusinessLogic> logger,
            IFacebookApiRepository facebookApiRepository) : base(unitOfWork, mapper, logger)
        {
            _facebookApiRepository = facebookApiRepository;
            _getUserByEmail = new GetUserByEmail(unitOfWork);
        }

        protected override IEnumerable<IValidator<FacebookLoginBindingModel>> Validators =>
            Enumerable.Empty<IValidator<FacebookLoginBindingModel>>();
        protected override async Task<TokenDto> ExecutionAsync(FacebookLoginBindingModel parameter)
        {
            var isTokenValid = await _facebookApiRepository.ValidateTokenAsync(parameter.Token);

            if (!isTokenValid)
            {
                throw new UnauthorizedAccessException();
            }

            var facebookUserDto = await _facebookApiRepository.GetUserInfoAsync(parameter.Token);

            var userDto = await _getUserByEmail.ExecuteAsync(facebookUserDto.Email, false);

            if (userDto == null)
            {

            }

            return new TokenDto();
        }
    }
}
