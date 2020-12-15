using System;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.CustomEntities
{
    public class Navegation:BaseQueryFilter
    {
        public int TotalItem { get; set; }
       // public int? ItemByPage { get; set; }
        public int? Pages { get; set; }
       // public int? Current { get; set; }
        public int? Next { get; set; }
        public int? Previous { get; set; }
    }
}
