using AuctionSite.BL.Common.Services;
using AuctionSite.BL.User.Interfaces;
using AuctionSite.BL.User;
using AuctionSite.Shared.BindingModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionSite.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IRegisterUserLogic _registerUserLogic;
        private readonly IUserFacebookAuthenticationLogic _userFacebookAuthenticationBusinessLogic;
        private readonly EmailService _emailService;

        public UserController(IRegisterUserLogic registerUserLogic, IUserFacebookAuthenticationLogic userFacebookAuthenticationBusinessLogic, EmailService emailService)
        {
            _registerUserLogic = registerUserLogic;
            _userFacebookAuthenticationBusinessLogic = userFacebookAuthenticationBusinessLogic;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserBindingModel registerBindingModel)
        {
            var result = await _registerUserLogic.ExecuteAsync<RegisterUserLogic>(registerBindingModel);
            _emailService.SendMessage(registerBindingModel);

            return CreateResponse(result);
        }

        [HttpPost("login/facebook")]
        public async Task<IActionResult> FacebookLoginAsync([FromBody] FacebookLoginBindingModel facebookLoginBindingModel)
        {
            var result = await _userFacebookAuthenticationBusinessLogic.ExecuteAsync<UserFacebookAuthenticationLogic>(facebookLoginBindingModel);
            return CreateResponse(result);
        }

        [HttpPost("sendEmailTest")]
        public IActionResult SendEmailTest()
        {
            //_emailService.SendMessage();
            return Ok();
        }
    }
}