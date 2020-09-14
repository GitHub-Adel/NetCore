using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Core.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public Paged Pagination { get; }
        public PagedList(List<T> list, int itemByPage, int currentPage)
        {
            var pages = list.Count / itemByPage;
            pages = pages > 1 ? pages : 1;
            var current = currentPage > pages ? pages : currentPage;
            var next = current < pages ? current + 1 : current;
            var previous = current > 1 ? current - 1 : current;


            Pagination = new Paged
            {
                TotalItem = list.Count,
                ItemByPage = itemByPage,
                Pages = pages,
                Current = current,
                Next = next,
                Previous = previous
            };

            list = list.Skip((currentPage - 1) * itemByPage).Take(itemByPage).ToList(); //skip=omitir, take=tomar            
            AddRange(list);
        }        

    }





}
