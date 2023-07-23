using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("Compra", Schema = "dbo")]
    public class Compra
    {
        [Key]
        public int Id_Compra{ get; set; }
        public int Id_Provedor { get; set; }
        public float Total { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual ICollection<DetalleCompra>DetalleCompras { get; set; }
    }
}