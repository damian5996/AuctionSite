using AuctionSite.BL.Common;
using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.BL.User.Validators
{
    public class UserExistenceValidator : IValidator<RegisterUserBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(RegisterUserBindingModel registerUserBindingModel)
        {
            var userWithEmailExists = _unitOfWork.User.WithThisEmailExists(registerUserBindingModel.Email);

            if (userWithEmailExists)
                throw new BusinessLogicException(
                    string.Format(Constants.Error.EmailExistsTemplate, registerUserBindingModel.Email), ExceptionType.BadRequest);

            var userWithUsernameExists = _unitOfWork.User.WithThisUsernameExists(registerUserBindingModel.Username);

            if (userWithUsernameExists)
                throw new BusinessLogicException(
                    string.Format(Constants.Error.UsernameExistsTemplate, registerUserBindingModel.Username), ExceptionType.BadRequest);
        }
    }
}
