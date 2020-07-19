using System;
using System.Collections.Generic;

namespace SocialMedia.Api
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Posts = new HashSet<Posts>();
        }

        public int UserId { get; set; }
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime Datebirth { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
    }
}
