using System.Threading.Tasks;
using AuctionSite.BL.User.Interface;
using AuctionSite.Shared.BindingModel;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSite.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserFacebookAuthenticationBusinessLogic _userFacebookAuthenticationBusinessLogic;

        public UserController(IUserFacebookAuthenticationBusinessLogic userFacebookAuthenticationBusinessLogic)
        {
            _userFacebookAuthenticationBusinessLogic = userFacebookAuthenticationBusinessLogic;
        }

        [HttpPost("login/facebook")]
        public async Task<IActionResult> FacebookLoginAsync([FromBody] FacebookLoginBindingModel facebookLoginBindingModel)
        {
            var result = await _userFacebookAuthenticationBusinessLogic.ExecuteAsync(facebookLoginBindingModel);
            return CreateResponse(result);
        }
    }
}