using System;

namespace SocialMedia.Api.QueryFilters
{
   
    public class UserQueryFilter:BaseQueryFilter
    {
        public int? UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
