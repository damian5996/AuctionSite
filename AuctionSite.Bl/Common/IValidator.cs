using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.BL.Common
{
    internal interface IValidator<in TParam>
    {
        void Validate(TParam param);
    }
}
