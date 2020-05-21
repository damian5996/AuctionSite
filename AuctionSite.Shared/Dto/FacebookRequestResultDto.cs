using System.Text.Json.Serialization;

namespace AuctionSite.Shared.Dto
{
    public class FacebookRequestResultDto<T>
    {
        [JsonPropertyName("data")]
        public T Content { get; set; }
    }
}
