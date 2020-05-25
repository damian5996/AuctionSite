using System.Threading.Tasks;
using AuctionSite.DataAccess;
using AuctionSite.Shared;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.Exceptions;

namespace AuctionSite.BL.User.Internal
{
    public class GetUserByEmail
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByEmail(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> ExecuteAsync(string email, bool throwIfNull = true)
        {
            var userDto = await _unitOfWork.User.GetByEmailOrDefaultAsync(email);

            if (userDto == null && throwIfNull)
            {
                throw new BusinessLogicException(
                    string.Format(Constants.Error.NotFoundTemplate, nameof(_unitOfWork.User), email),
                    ExceptionType.NotFound);
            }

            return userDto;
        }
    }
}
