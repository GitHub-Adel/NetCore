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
            PruebaDBContext db = new PruebaDBContext();

            var cliente1 = new Cliente
            {
                Nombre = "Rosmarlin sanchez perez"
            };
            var cliente2 = new Cliente
            {
                Nombre = "Sebastian sanchez perez"
            };

            db.Cliente.Add(cliente1);
            db.Cliente.Add(cliente2);
            db.SaveChanges();

            var clientes=db.Cliente.ToList();
            foreach (var item in clientes)
            {
                WriteLine($"cliente:{item.Nombre} ({item.ClienteId})");
            }

            // var Ordenes = db.Orden.Where(x => x.ClienteId == 1)
            //                    .Include(x => x.Cliente)
            //                    .ThenInclude(x => x.Vendedor)
            //                    .ToList();

            // var Ordenes2 = db.Orden.Where(x => x.ClienteId == 1)
            // .Select(x => new
            // {
            //     Orden = x,
            //     Cliente = x.Cliente,
            //     Vendedor = x.Cliente.Vendedor
            // }).ToList();




            // WriteLine($"Cliente :{Ordenes2[1].Cliente.Nombre} ({Ordenes[1].ClienteId})");
            // WriteLine($"vendedor:{Ordenes2[1].Vendedor.Nombre} ({Ordenes2[1].Vendedor.VendedorId})");
            // foreach (var item in Ordenes2)
            // {
            //     WriteLine($"Orden :{item.Orden.Detalle} ({item.Orden.OrdenId})");
            //     WriteLine("");
            // }

            //  WriteLine($"Cliente :{Ordenes[1].Cliente.Nombre} ({Ordenes[1].ClienteId})");
            // WriteLine($"vendedor:{Ordenes[1].Cliente.Vendedor.Nombre} ({Ordenes[1].Cliente.Vendedor.VendedorId})");
            // WriteLine("");
            // foreach (var item in Ordenes)
            // {                               
            //     WriteLine($"Orden :{item.Detalle} ({item.OrdenId})");                
            // }

        }
    }
}
