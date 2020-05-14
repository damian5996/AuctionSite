using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.DataAccess.Model
{
    public class Opinion
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public short Rate { get; set; }
        public long AuthorId { get; set; }
        public long AuctionId { get; set; }

        public virtual User Author { get; set; }
    }
}
