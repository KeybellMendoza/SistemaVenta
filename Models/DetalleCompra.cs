using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("DetalleCompra", Schema = "dbo")]
    public class DetalleCompra
    {
        [Key]
        public int Id_DetalleCompra { get; set; }
        [ForeignKey("Compra")]
        public int Compra_Id { get; set; }
        [ForeignKey("Producto")]
        public int Producto_Id { get; set; }
        public float Precio_Compra { get; set; }
        public float Precio_Venta { get; set; }
        public float Cantidad { get; set; }
        public float Sub_Total { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto {get; set;}
    }
}