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

            public const string EmailExistsTemplate = "User with email '{0}' already exists! Choose another email or try log in via Facebook/Google :)";
            public const string UsernameExistsTemplate = "User with username '{0}' already exists!";

            public const string EmailWrongFormat = "Email has a wrong format";

            public const string PasswordNotComplex = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character";
        }

        public static class Configuration
        {
            public const string FacebookAuthRoot = "facebook-auth";
            public const string FacebookApiConfigurationRoot = "facebook-api-configuration";
        }

        public static class Other
        {
            public const string PasswordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}";
        }
    }
}
