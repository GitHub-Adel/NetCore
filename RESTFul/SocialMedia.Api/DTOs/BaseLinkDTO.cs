using System.Collections.Generic;
using SocialMedia.Api.CustomEntities;

namespace SocialMedia.Api.DTOs
{
    public abstract class BaseLinkDTO
    {
       public IList<Link> Links { get; set; } = new List<Link>();
    }
}