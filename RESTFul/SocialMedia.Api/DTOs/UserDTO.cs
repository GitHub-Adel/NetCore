using System;
using System.Collections.Generic;

namespace SocialMedia.Api.DTOs
{
    public class UserDTO:BaseLinkDTO
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
              
    }
}
