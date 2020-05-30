using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class Orden
    {
        [Key]
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}