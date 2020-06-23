using System.Text.Json.Serialization;

namespace AuctionSite.Shared.Dto.Facebook
{
    public class FacebookSimpleUserDto
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("is_valid")]
        public bool IsValidated { get; set; }
    }
}
