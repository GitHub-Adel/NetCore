using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Models
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions<PruebaDbContext> options) : base(options)
        {
        }        
        //declaro una propiedad de tipo DbSet<T> para cada modelo
        public DbSet<Cliente> Cliente {get;set;}
        public DbSet<Orden> Orden {get;set;}
    }
}
