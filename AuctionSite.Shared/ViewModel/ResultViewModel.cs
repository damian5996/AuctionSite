using AuctionSite.Shared.Enums;

namespace AuctionSite.Shared.ViewModel
{
    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }

        public ExceptionType? ExceptionType;

        public bool IsValid => string.IsNullOrWhiteSpace(Error);
    }
}
