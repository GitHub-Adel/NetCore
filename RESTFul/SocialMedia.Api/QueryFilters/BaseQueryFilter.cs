namespace SocialMedia.Api.QueryFilters
{
    public abstract class BaseQueryFilter
    {
        public int? ItemByPage { get; set; }
        public int? CurrentPage { get; set; }
    }
}