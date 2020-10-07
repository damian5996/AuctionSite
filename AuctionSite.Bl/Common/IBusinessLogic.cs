using AuctionSite.Shared.ViewModel;
using System.Threading.Tasks;

namespace AuctionSite.BL.Common
{
    public interface IBusinessLogic<in TParam, TResult>
    {
        Task<ResultViewModel<TResult>> ExecuteAsync<TLogic>(TParam parameter);
    }

    public interface IBusinessLogic<TResult> 
    {
        Task<ResultViewModel<TResult>> ExecuteAsync();
    }
}
