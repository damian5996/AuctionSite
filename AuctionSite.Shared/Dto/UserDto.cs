using AuctionSite.Shared.Enums;
using System;

namespace AuctionSite.Shared.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public DateTime? BirthDate { get; set; }
        public short FailedLoginAttempts { get; set; }
        public Guid? RecoveryGuid { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public bool IsSuperSeller { get; set; }
        public DateTime? RecoveryValidDate { get; set; }
        public string PhoneNumber { get; set; }

        //public virtual ICollection<UserOpinionThumb> UserOpinionThumbs { get; set; }
        //public virtual ICollection<Auction> BoughtAuctions { get; set; }
        //public virtual ICollection<Auction> CreatedAuctions { get; set; }
        //public virtual ICollection<Bid> Bids { get; set; }
        //public virtual ICollection<ReportedAuction> ReportedAuctions { get; set; }
        //public virtual ICollection<Opinion> Opinions { get; set; }
    }
}
