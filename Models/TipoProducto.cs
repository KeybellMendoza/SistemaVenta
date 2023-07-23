using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaVenta.Models
{
    [Table("Tipo_Producto", Schema = "dbo")]
    public class Tipo_Producto
    {
        [Key]
        public int Id_Tipo_Producto { get; set; }
        public string Descripcion { get; set; }
    }
}