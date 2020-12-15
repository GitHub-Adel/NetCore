using System;
using System.Collections.Generic;

namespace SocialMedia.Api.Models
{
    public partial class Security
    {
        public int SecurityId { get; set; }
        public int RoleId { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual Role Role { get; set; }
    }
}


