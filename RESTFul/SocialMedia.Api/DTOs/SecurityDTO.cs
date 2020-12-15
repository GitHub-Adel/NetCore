namespace SocialMedia.Api.DTOs
{
    public class SecurityDTO:BaseLinkDTO
    {
        public int SecurityId { get; set; }
        public int RoleId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}