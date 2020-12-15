namespace SocialMedia.Api.QueryFilters
{
    public class RoleQueryFilter:BaseQueryFilter
    {
        public int? RoleId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}