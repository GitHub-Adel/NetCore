using System;

namespace SocialMedia.Core.Entity
{
    public class Post
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
