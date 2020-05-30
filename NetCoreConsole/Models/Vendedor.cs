using System;
using System.Collections.Generic;

namespace NetCoreConsole.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Cliente = new HashSet<Cliente>();
        }

        public int VendedorId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
