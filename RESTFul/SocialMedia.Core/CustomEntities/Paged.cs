using System;

namespace SocialMedia.Core.CustomEntities
{
    public class Paged
    {
        public int TotalItem { get; internal set; }
        public int ItemByPage { get; internal set; }
        public int Pages { get; internal set; }
        public int Current { get; internal set; }
        public int Next { get; internal set; }
        public int Previous { get; internal set; }
    }
}
