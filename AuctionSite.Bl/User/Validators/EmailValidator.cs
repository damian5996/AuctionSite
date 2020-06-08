using AuctionSite.BL.Common;
using AuctionSite.Shared;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace AuctionSite.BL.User.Validators
{
    public class EmailFormatValidator : IValidator<RegisterUserBindingModel>
    {
        public void Validate(RegisterUserBindingModel registerUserBindingModel)
        {
            var validEmail = new EmailAddressAttribute().IsValid(registerUserBindingModel.Email);

            if (!validEmail)
                throw new BusinessLogicException(Constants.Error.EmailWrongFormat, ExceptionType.BadRequest);
        }
    }
}
