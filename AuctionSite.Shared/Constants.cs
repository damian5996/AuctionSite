namespace AuctionSite.Shared
{
    public static class Constants
    {
        public static class Database
        {
            public const string DefaultConnectionString = "Default";
        }

        public static class Error
        {
            public const string Default = "Something went wrong!";
            public const string Fatal = "Fatal error!";

            public const string NotFoundTemplate = "{0} [{1}] not found!";
        }

        public static class Configuration
        {
            public const string FacebookAuthRoot = "facebook-auth";
            public const string FacebookApiConfigurationRoot = "facebook-api-configuration";
        }
    }
}
