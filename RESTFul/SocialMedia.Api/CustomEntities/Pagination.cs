using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SocialMedia.Api.QueryFilters;

namespace SocialMedia.Api.CustomEntities
{
    public class Pagination<Tipo>  where Tipo : class
    {
        public IList<Tipo> ListaPaginada { get;}            
        public int TotalPaginas { get;}
        public int TotalItems { get;}
        public int ItemsPorPagina { get; }
        public int PaginaActual { get; }        
        public int PaginaProxima { get; }
        public int PaginaAnterior { get;}
        public Pagination(IList<Tipo> lista, int paginaActual, int itemsPorPagina)
        {
            ListaPaginada= lista.Skip( ((paginaActual- 1) * itemsPorPagina)).Take(itemsPorPagina).ToList();
            TotalPaginas = lista.Count() / itemsPorPagina;            
            TotalPaginas = TotalPaginas > 1 ? TotalPaginas : 1;
            TotalItems = lista.Count();
            ItemsPorPagina=itemsPorPagina;
            PaginaActual = paginaActual > TotalPaginas ? TotalPaginas : PaginaActual;
            PaginaProxima = PaginaActual < TotalPaginas ? PaginaActual + 1 : PaginaActual;
            PaginaAnterior = PaginaActual > 1 ? PaginaActual - 1 : PaginaActual;
        }


    }
}
