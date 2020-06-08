using AuctionSite.BL.Common;
using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AuctionSite.BL.User.Validators
{
    public class PasswordValidator : IValidator<RegisterUserBindingModel>
    {
        public void Validate(RegisterUserBindingModel registerUserBindingModel)
        {
            var correctPassword = Regex.IsMatch(registerUserBindingModel.Password, Constants.Other.PasswordRegex);

            if (!correctPassword)
                throw new BusinessLogicException(Constants.Error.PasswordNotComplex, ExceptionType.BadRequest);
        }
    }
}
