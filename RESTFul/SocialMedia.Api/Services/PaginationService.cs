using System.Collections.Generic;
using System.Linq;
using SocialMedia.Api.CustomEntities;
using SocialMedia.Api.Interfaces;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.Services
{
    public class PaginationService<T>: IPaginationService<T>   where T : class
    {
        private readonly IAppsettingService appsetting;

        public PaginationService(IAppsettingService appsetting)
        {
            this.appsetting = appsetting;
        }

        //retorna la lista paginada.  //skip=omitir, take=tomar  
        public IList<T> GetPagedList(IList<T> list, BaseQueryFilter filter=null)
        {
            if (filter.ItemByPage == null) filter.ItemByPage = appsetting.ItemByPage;
            if (filter.CurrentPage == null) filter.CurrentPage = appsetting.CurrentPage;

            return list.Skip( ((filter.CurrentPage - 1) * filter.ItemByPage).Value).Take(filter.ItemByPage.Value).ToList();
        }


    }
}
