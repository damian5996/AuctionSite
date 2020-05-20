using AuctionSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AuctionSite.Shared.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public ExceptionType ExceptionType;
        public BusinessLogicException() : this(Constants.Error.Default)
        {
        }
        public BusinessLogicException(string errorMessage) : this(errorMessage, ExceptionType.InternalServerError)
        {
        }

        public BusinessLogicException(string errorMessage, ExceptionType exceptionType) : base(errorMessage)
        {
            ExceptionType = exceptionType;
        }

        public BusinessLogicException(Exception ex) : this(ex.Message, ExceptionType.InternalServerError, ex)
        {
        }

        public BusinessLogicException(string errorMessage, ExceptionType exceptionType, Exception ex) : base(errorMessage, ex)
        {
            ExceptionType = exceptionType;
        }
    }
}
