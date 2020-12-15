using System.Collections.Generic;
using SocialMedia.Api.CustomEntities;

namespace SocialMedia.Api.DTOs
{
    public class RoleDTO:BaseLinkDTO
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        
    }
}