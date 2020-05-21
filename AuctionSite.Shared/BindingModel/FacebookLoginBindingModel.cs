using System.ComponentModel.DataAnnotations;

namespace AuctionSite.Shared.BindingModel
{
    public class FacebookLoginBindingModel
    {
        [Required]
        public string Token { get; set; }
    }
}
