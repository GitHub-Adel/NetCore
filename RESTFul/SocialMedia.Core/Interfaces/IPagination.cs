using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Interfaces
{
    public interface IPagination<T>  where T : class
    {
        IEnumerable<T> GetPagedList(IEnumerable<T> list, int? itemByPage=null, int? currentPage=null);
       object GetNavegation(IEnumerable<T> list, int? itemByPage = null, int? currentPage = null);
    }
}
