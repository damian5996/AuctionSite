using AuctionSite.BL.User.Interfaces;
using AuctionSite.Shared.BindingModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionSite.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IRegisterUserLogic _registerUserLogic;
        private readonly IUserFacebookAuthenticationLogic _userFacebookAuthenticationBusinessLogic;

        public UserController(IRegisterUserLogic registerUserLogic, IUserFacebookAuthenticationLogic userFacebookAuthenticationBusinessLogic)
        {
            _registerUserLogic = registerUserLogic;
            _userFacebookAuthenticationBusinessLogic = userFacebookAuthenticationBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserBindingModel registerBindingModel)
        {
            var result = await _registerUserLogic.ExecuteAsync(registerBindingModel);

            return CreateResponse(result);
        }

        [HttpPost("login/facebook")]
        public async Task<IActionResult> FacebookLoginAsync([FromBody] FacebookLoginBindingModel facebookLoginBindingModel)
        {
            var result = await _userFacebookAuthenticationBusinessLogic.ExecuteAsync(facebookLoginBindingModel);
            return CreateResponse(result);
        }
    }
}