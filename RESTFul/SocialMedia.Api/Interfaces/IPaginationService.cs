using System;
using System.Collections.Generic;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Interfaces
{
    public interface IPaginationService<T>  where T : class
    {
        IList<T> GetPagedList(IList<T> list, BaseQueryFilter filter=null);
        //Navegation GetNavegation(IList<T> list, BaseQueryFilter filter=null);
    }
}
