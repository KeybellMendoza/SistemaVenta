using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("Producto", Schema = "dbo")]
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }
        [ForeignKey("Provedor")]
        public int Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Inventario { get; set; }
        [ForeignKey("Tipo_Producto")]
        public int Id_Tipo { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }

        public virtual Provedor Provedor { get; set; }
        public virtual Tipo_Producto Tipo_Producto { get; set; }

    }
}