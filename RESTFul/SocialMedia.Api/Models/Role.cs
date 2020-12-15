using System;
using System.Collections.Generic;

namespace SocialMedia.Api.Models
{
    public partial class Role
    {
        public Role()
        {
            Security = new HashSet<Security>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Security> Security { get; set; }
    }
}
