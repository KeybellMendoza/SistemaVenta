using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("Provedor", Schema = "dbo")]
    public class Provedor
    {
        [Key]
        public int Id_Provedor { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string Razon_Social { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }

    }
}