using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;
using AuctionSite.Shared.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuctionSite.BL.Common
{
    public abstract class BaseLogic<TExecution, TResult>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        private ILogger _logger;

        protected BaseLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            _logger = logger;
        }

        protected async Task<ResultViewModel<TResult>> HandleExecutionAsync(Func<Task<TExecution>> execution)
        {
            try
            {
                var result = await execution();

                return new ResultViewModel<TResult>
                {
                    Data = Mapper.Map<TResult>(result),
                };
            }
            catch (BusinessLogicException ex)
            {
                _logger.LogError(ex.Message);
                return new ResultViewModel<TResult>
                {
                    Error = ex.Message,
                    ExceptionType = ex.ExceptionType
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex.Message);

                return new ResultViewModel<TResult>
                {
                    Error = Constants.Error.Default,
                    ExceptionType = ExceptionType.Unauthorized
                };
            }
            catch (Exception ex)
            {
                do
                {
                    _logger.LogError(ex.Message);
                    ex = ex.InnerException;
                } while (ex != null);

                return new ResultViewModel<TResult>
                {
                    Error = Constants.Error.Default,
                    ExceptionType = ExceptionType.InternalServerError
                };
            }
        }
    }
}
