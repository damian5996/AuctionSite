using AuctionSite.BL.User.Interfaces;
using AuctionSite.Shared.BindingModel;
using AuctionSite.Shared.Dto;
using AuctionSite.Shared.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuctionSite.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IRegisterUserLogic _registerUserLogic;

        public UserController(IRegisterUserLogic registerUserLogic)
        {
            _registerUserLogic = registerUserLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserBindingModel registerBindingModel)
        {
            var result = await _registerUserLogic.ExecuteAsync(registerBindingModel);

            return CreateResponse<long>(result);
        }
    }
}