using AuctionSite.BL.Common;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.BL.User.Internal;
using AuctionSite.DataAccess;
using AuctionSite.DataAccess.Repositories.Interfaces;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;

namespace AuctionSite.BL.User
{
    internal class UserFacebookAuthenticationLogic : BaseBusinessLogic<FacebookLoginBindingModel, TokenDto, TokenViewModel>, IUserFacebookAuthenticationLogic
    {
        private readonly IFacebookApiRepository _facebookApiRepository;
        private readonly GetUserByEmail _getUserByEmail;

        public UserFacebookAuthenticationLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserFacebookAuthenticationLogic> logger,
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
                throw new BusinessLogicException("", ExceptionType.Unauthorized);
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
