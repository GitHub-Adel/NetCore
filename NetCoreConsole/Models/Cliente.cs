using System;
using System.Collections.Generic;

namespace NetCoreConsole.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Orden = new HashSet<Orden>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public int? VendedorId { get; set; }
        public string Cedula { get; set; }

        public virtual Vendedor Vendedor { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
