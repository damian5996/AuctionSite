using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.Shared.Enums
{
    public enum ExceptionType
    {
        BadRequest = 400,
        Unauthorized = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
