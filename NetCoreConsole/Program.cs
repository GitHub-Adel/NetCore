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
            var vendedores=new List<Vendedor>(){
                new Vendedor{Nombre="Angel"} ,
                new Vendedor{Nombre="Nolasco"} ,
                new Vendedor{Nombre="Angelo"}
                
                };

            var clientes=new List<Cliente>(){
                new Cliente(){Nombre="Adelson",VendedorId=1},
                new Cliente(){Nombre="Rosalis",VendedorId=1},
                new Cliente(){Nombre="Jeuris",VendedorId=2},
                new Cliente(){Nombre="Juan",VendedorId=2}

            }   ; 

            
               
            var resultado= vendedores.Join(clientes, 
                                        cliente => cliente.VendedorId,
                                        vendedor => vendedor.VendedorId,
                                        (cliente,vendedor) => new{
                                            clienteNombre=cliente.Nombre,
                                            vendedorNombre = vendedor.
                                        });

            foreach (var item in resultado)
            {
                 WriteLine($"Cliente nombre:{item.clienteNombre}");
                 WriteLine($"Vendedor nombre:{item.vendedorNombre}");
            }   
            WriteLine(vendedores.Count());                              
            WriteLine(clientes.Count());                              
        }


    }
}
