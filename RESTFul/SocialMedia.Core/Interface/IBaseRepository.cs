using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interface
{
    //generic interface
    public  interface IBaseRepository<T> where T: class
    {       
        Task Add(T entity);
    }


}
