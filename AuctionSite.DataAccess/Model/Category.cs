﻿using System.Collections.Generic;

namespace AuctionSite.DataAccess.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}
