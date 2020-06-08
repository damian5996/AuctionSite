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
    internal class RegisterUserLogic : BaseBusinessLogic<RegisterUserBindingModel, UserDto, RegisterUserViewModel>, IRegisterUserLogic
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
                new UserExistenceValidator(UnitOfWork),
                new PasswordValidator()
            };

        protected override async Task<UserDto> ExecutionAsync(RegisterUserBindingModel registerUserBindingModel)
        {
            var user = Mapper.Map<UserDto>(registerUserBindingModel);
            user.PasswordHash = GetHash(registerUserBindingModel.Password);
            user.Role = Role.User;
            await UnitOfWork.User.AddUser(user);
            return user;
        }

        private string GetHash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
  
                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }

    }
}
