using System;
using System.Collections.Generic;

namespace SocialMedia.Api.CustomEntities
{
    public class ResponseApi<T> where T : class
    {
        public T Data { get; set; }
        public Navegation Navegation { get; set; }
        public List<Link> Links { get; set; } 
        public ResponseApi(T data, Navegation  navegation=null)
        {          
            // var list=(List<T>)Convert.ChangeType(data, typeof(List<T>));
            this.Data=data;
            this.Navegation=navegation; 
            this.Links= new List<Link>();        
        }

    }

}
