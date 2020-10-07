using AuctionSite.BL.Common;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.BL.User.Internal;
using AuctionSite.BL.User.Validators;
using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using AuctionSite.Shared.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSite.BL.User
{
    public class RegisterUserLogic : BaseBusinessLogic<RegisterUserBindingModel, bool, bool>, IRegisterUserLogic
    {
        public RegisterUserLogic(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            ILogger<RegisterUserLogic> logger) 
            : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<RegisterUserBindingModel>> Validators =>

            new IValidator<RegisterUserBindingModel>[]
            {
                new UserUniquenessValidator(UnitOfWork),
                new PasswordValidator()
            };

        protected override async Task<bool> ExecutionAsync(RegisterUserBindingModel registerUserBindingModel)
        {
            var userDto = MapUser(registerUserBindingModel);

            return await UnitOfWork.User.AddUser(userDto);
        }

        private UserDto MapUser(RegisterUserBindingModel registerUserBindingModel)
        {
            var user = Mapper.Map<UserDto>(registerUserBindingModel);
            user.PasswordHash = registerUserBindingModel.Password.GetHash();
            user.Role = Role.User;
            user.RecoveryGuid = Guid.NewGuid();
            user.CreationDate = DateTime.UtcNow;

            return user;
        }

        

    }
}
