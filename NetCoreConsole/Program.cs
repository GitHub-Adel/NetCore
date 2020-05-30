using System;

namespace NetCoreConsole
{
    using static System.Console;
    using Models;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            PruebaDBContext db =new PruebaDBContext();
            List<Orden> Ordenes= db.Orden.Where(x => x.ClienteId==1)
                               .Include(x=>x.Cliente)
                               .ThenInclude(x=>x.Vendedor)
                               .ToList();

            Cliente clien


            
            WriteLine("");
            WriteLine($"Cliente :{Ordenes[1].Cliente.Nombre} ({Ordenes[1].ClienteId})");
            WriteLine($"vendedor:{Ordenes[1].Cliente.Vendedor.Nombre} ({Ordenes[1].Cliente.VendedorId})");
            foreach (var item in Ordenes)
            {                               
                WriteLine($"Orden :{item.Detalle} ({item.OrdenId})");
                WriteLine("");
            }
            
        }
    }
}
