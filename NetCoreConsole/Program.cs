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
            var consulta=new ConsultaSql(new PruebaDBContext());
           consulta.Script=$"exec OrdenByCliente 1";
           consulta.Ejecutar();
           while(consulta.Recorre()){
               WriteLine($"valor[{consulta.Valores[0]}] valor[{consulta.Valores[1]}] valor[{consulta.Valores[2]}]");
           }
            //consulta.Valores.Close();
        }



    }
}
