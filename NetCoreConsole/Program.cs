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
            var resultado = db.Cliente.OrderByDescending(entrada => entrada.Nombre).ToList(); // entrada => entrada.Nombre );
            foreach (var item in resultado)
            {
                WriteLine(item.Nombre);
            }

        }


    }
}
