using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.Shared.Dto
{
    public class EmailMessageDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
