using System;
using System.Collections.Generic;

#nullable disable

namespace Security.Service.API.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime Dob { get; set; }
        public string EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsFirstTimeUser { get; set; }
        public int? WorngAttempts { get; set; }
        public long? ContactNo { get; set; }
        public string Gender { get; set; }

        public virtual Role Role { get; set; }
    }
}
