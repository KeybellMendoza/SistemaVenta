using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("Venta", Schema = "dbo")]
    public class Venta
    {
        [Key]
        public int Id_Venta { get; set; }

        public float Monto_Pago { get; set; }

        public float Cambio { get; set; }

        public DateTime Fecha_Registro { get; set; }

        public string Nombre_Cliente { get; set; }

        public string Nombre_Documento { get; set; }

        public virtual ICollection<DetalleVenta>DetalleVentas { get; set; }
        
        

    }
}