using AuctionSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.DataAccess.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public DateTime BirthDate { get; set; }
        public int FailedLoginAttempts { get; set; }
        public Guid RecoveryGuid { get; set; }
        public string Username { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletionDate { get; set; }
        public string LastModificationDate { get; set; }
        public string PasswordHash { get; set; }
        public RoleEnum Role { get; set; }
        public bool IsSuperSeller { get; set; } //?
        public DateTime RecoveryValidDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
