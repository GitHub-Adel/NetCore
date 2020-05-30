using System.ComponentModel.DataAnnotations;

namespace proyecto.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
    }
}