using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaVenta.Data
{
    public class SistemaVentaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SistemaVentaContext() : base("name=SistemaVentaContext")
        {
        }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Compra> Compras { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.DetalleCompra> DetalleCompras { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.DetalleVenta> DetalleVentas { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Venta> Ventas { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Provedor> Provedors { get; set; }

        public System.Data.Entity.DbSet<SistemaVenta.Models.Tipo_Producto> Tipo_Producto { get; set; }
    }
}
