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
        static PruebaDBContext db = new PruebaDBContext();        
        static void Main(string[] args)
        {                   
            var resultado = db.Cliente.ToLookup(cliente => cliente.VendedorId);
            foreach (var grupo in resultado)
            {
                WriteLine($"vendedor:{grupo.Key} {db.Vendedor.Find(grupo.Key).Nombre}");
                WriteLine("========================");
                foreach (var cliente in grupo)
                {
                    WriteLine($"{cliente.Nombre}");
                }
                WriteLine($"");
            }

        }


    }
}
