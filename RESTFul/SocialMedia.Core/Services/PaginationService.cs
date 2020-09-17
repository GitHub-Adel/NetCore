using System.Collections.Generic;
using System.Linq;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.Core.Services
{
    public class PaginationService<T>: IPagination<T>   where T : class
    {
        private readonly IAppsetting appsetting;

        public PaginationService(IAppsetting appsetting)
        {
            this.appsetting = appsetting;
        }

        //retorna la lista paginada.  //skip=omitir, take=tomar  
        public IEnumerable<T> GetPagedList(IEnumerable<T> list, int? itemByPage = null, int? currentPage = null)
        {
            if (itemByPage == null) itemByPage = appsetting.ItemByPage;
            if (currentPage == null) currentPage = appsetting.CurrentPage;

            return list.Skip((currentPage.Value - 1) * itemByPage.Value).Take(itemByPage.Value).ToList();
        }

        //retorna el paginado(next=3, previeus=1 etc.) con hipermedia
        public object GetNavegation(IEnumerable<T> list, int? itemByPage = null, int? currentPage = null)
        {
            var pages = list.Count() / itemByPage;
            pages = pages > 1 ? pages : 1;
            var current = currentPage > pages ? pages : currentPage;
            var next = current < pages ? current + 1 : current;
            var previous = current > 1 ? current - 1 : current;

            return new
            {
                TotalItem = list.Count(),
                //ItemByPage = itemByPage.Value,
                Pages = pages,
               // Current = current,
                Next = next,
                Previous = previous
            };
        }

    }
}
