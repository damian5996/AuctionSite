﻿namespace AuctionSite.Shared.Configuration
{
    public class FacebookApiConfiguration
    {
        public string BaseUrl { get; set; }
        public string ValidateTokenMethodPathTemplate { get; set; }
        public string GetUserMethodPathTemplate { get; set; }
        public string AccessToken { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
