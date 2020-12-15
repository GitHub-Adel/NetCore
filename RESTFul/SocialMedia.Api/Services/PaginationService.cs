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

        //retorna la filter del paginado(next=3, previeus=1 etc.)
        public Navegation GetNavegation(IList<T> list, BaseQueryFilter filter=null)
        {
            if ( (list.Count()==0) || (filter==null) ) return default(Navegation);

            if (filter.ItemByPage == null) filter.ItemByPage = appsetting.ItemByPage;
            if (filter.CurrentPage == null) filter.CurrentPage = appsetting.CurrentPage;

            var pages = list.Count() / filter.ItemByPage;
            pages = pages > 1 ? pages : 1;
            var current = filter.CurrentPage > pages ? pages : filter.CurrentPage;
            var next = current < pages ? current + 1 : current;
            var previous = current > 1 ? current - 1 : current;

            return new Navegation
            {
                TotalItem = list.Count(),
                ItemByPage = filter.ItemByPage,
                Pages = pages,
                CurrentPage = current,
                Next = next,
                Previous = previous
            };
        }

    }
}
