using System;
using System.Collections.Generic;
using System.Linq;
using SocialMedia.Core.Entity;

namespace SocialMedia.Infrastructure.Repositoy
{
    public class PostRepository
    {
      public IEnumerable<Post> GetPosts(){
           return Enumerable.Range(1,10).Select(x =>new Post
           {
               PostID=x
               ,UserID=x+1
               ,Description="Description"+x
               ,Date=DateTime.Now
               ,Image="https://imagen.com.do"
           });
       }
    }
}
