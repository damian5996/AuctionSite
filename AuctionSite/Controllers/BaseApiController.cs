using AuctionSite.Shared;
using AuctionSite.Shared.Enums;
using AuctionSite.Shared.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(ResultViewModel<T> result)
        {
            if (result.IsValid)
            {
                return Ok(result.Data);
            }

            return result.ExceptionType != null
                ? StatusCode((int)(result.ExceptionType), result.Error)
                : StatusCode(500, Constants.Error.Fatal);

        }
    }
}