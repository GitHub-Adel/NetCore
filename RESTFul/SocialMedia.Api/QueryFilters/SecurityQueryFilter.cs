using System;

namespace SocialMedia.Api.QueryFilters
{
    public class SecurityQueryFilter:BaseQueryFilter
    {
        public int? SecurityId { get; set; }
        public int? RoleId { get; set; }
        public string User { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
