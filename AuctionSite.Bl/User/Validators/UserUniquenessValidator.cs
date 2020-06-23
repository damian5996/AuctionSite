using AuctionSite.BL.Common;
using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctionSite.BL.User.Validators
{
    public class UserUniquenessValidator : IValidator<RegisterUserBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(RegisterUserBindingModel registerUserBindingModel)
        {
            ValidateEmailUniqueness(registerUserBindingModel.Email);
            ValidateUsernameUniqueness(registerUserBindingModel.Username);
        }

        private void ValidateEmailUniqueness(string email)
        {
            var userWithEmailExists = _unitOfWork.User.GetAll().Any(u => u.Email == email);

            if (userWithEmailExists)
                throw new BusinessLogicException(
                    string.Format(Constants.Error.EmailExistsTemplate, email), ExceptionType.BadRequest);
        }

        private void ValidateUsernameUniqueness (string username)
        {
            var userWithUsernameExists = _unitOfWork.User.GetAll().Any(u => u.Username == username);

            if (userWithUsernameExists)
                throw new BusinessLogicException(
                    string.Format(Constants.Error.UsernameExistsTemplate, username), ExceptionType.BadRequest);
        }
    }
}
