using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("DetalleVenta", Schema = "dbo")]
    public class DetalleVenta
    {
        [Key]
        public int Id_DetalleVenta { get; set; }
        [ForeignKey("Venta")]
        public int Id_Venta { get; set; }
        [ForeignKey("Producto")]
        public int Id_Producto { get; set; }
        public float Precio_Venta { get; set; }
        public float Cantidad { get; set; }
        public float Sub_Total { get; set; }
        public virtual Venta Venta  { get; set; }
        public virtual Producto Producto { get; set; }
    }
}