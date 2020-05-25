using AuctionSite.BL.Common;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.DataAccess;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSite.BL.User
{
    internal class RegisterUserLogic : BaseBusinessLogic<RegisterUserBindingModel, UserDto, long>, IRegisterUserLogic
    {
        public RegisterUserLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RegisterUserLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<RegisterUserBindingModel>> Validators => throw new NotImplementedException();

        protected override Task<UserDto> ExecutionAsync(RegisterUserBindingModel parameter)
        {
            return Task.FromResult(new UserDto());
        }

    }
}
