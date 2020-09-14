using System;

namespace SocialMedia.Core.QueryFilters
{
    public class UserQueryFilter
    {
        public int? UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Phone { get; set; }
        public int? ItemByPage { get; set; }
        public int? CurrentPage { get; set; }
    }
}
