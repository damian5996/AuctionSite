using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.Shared.BindingModel
{
    public class RegisterUserBindingModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
