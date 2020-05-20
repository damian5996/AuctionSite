using AuctionSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.Shared.ViewModel
{
    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public string Error { get; set; } //moze lista errorów?

        public ExceptionType? ExceptionType;

        public bool IsValid => string.IsNullOrWhiteSpace(Error);
    }
}
