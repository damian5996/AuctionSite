﻿using AuctionSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.DataAccess.Model
{
    public class Auction
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsBidType { get; set; }
        public decimal? Price { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public long? BoughtById { get; set; }
        public int? CategoryId { get; set; }
        public long OwnerId { get; set; }

        public virtual User BoughtBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
