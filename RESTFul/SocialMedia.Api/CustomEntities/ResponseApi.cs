using System;
using System.Collections.Generic;

namespace SocialMedia.Api.CustomEntities
{
    public class ResponseApi<T> where T : class
    {
        public T Data { get; set; }
        public List<Link> Links { get; set; } 
        public ResponseApi(T data)
        {          
            // var list=(List<T>)Convert.ChangeType(data, typeof(List<T>));
            this.Data=data;
            this.Links= new List<Link>();        
        }

    }

}
