using System;

namespace SocialMedia.Core.DTOs
{
    public class UserDTO
    {
       // public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
