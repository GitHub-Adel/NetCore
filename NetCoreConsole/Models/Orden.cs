using System;
using System.Collections.Generic;

namespace NetCoreConsole.Models
{
    public partial class Orden
    {
        public int OrdenId { get; set; }
        public string Detalle { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
