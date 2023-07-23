namespace SistemaVenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id_Cliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.Id_Cliente);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Id_Compra = c.Int(nullable: false, identity: true),
                        Id_Provedor = c.Int(nullable: false),
                        Total = c.Single(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Compra);
            
            CreateTable(
                "dbo.DetalleCompra",
                c => new
                    {
                        Id_DetalleCompra = c.Int(nullable: false, identity: true),
                        Compra_Id = c.Int(nullable: false),
                        Producto_Id = c.Int(nullable: false),
                        Precio_Compra = c.Single(nullable: false),
                        Precio_Venta = c.Single(nullable: false),
                        Cantidad = c.Single(nullable: false),
                        Sub_Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id_DetalleCompra)
                .ForeignKey("dbo.Compra", t => t.Compra_Id, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.Producto_Id, cascadeDelete: true)
                .Index(t => t.Compra_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id_Producto = c.Int(nullable: false, identity: true),
                        Id_Proveedor = c.Int(nullable: false),
                        Nombre = c.String(),
                        Cantidad = c.Int(nullable: false),
                        Fecha_Inventario = c.DateTime(nullable: false),
                        Id_Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Producto)
                .ForeignKey("dbo.Provedor", t => t.Id_Proveedor, cascadeDelete: true)
                .ForeignKey("dbo.Tipo_Producto", t => t.Id_Tipo, cascadeDelete: true)
                .Index(t => t.Id_Proveedor)
                .Index(t => t.Id_Tipo);
            
            CreateTable(
                "dbo.DetalleVenta",
                c => new
                    {
                        Id_DetalleVenta = c.Int(nullable: false, identity: true),
                        Id_Venta = c.Int(nullable: false),
                        Id_Producto = c.Int(nullable: false),
                        Precio_Venta = c.Single(nullable: false),
                        Cantidad = c.Single(nullable: false),
                        Sub_Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id_DetalleVenta)
                .ForeignKey("dbo.Producto", t => t.Id_Producto, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.Id_Venta, cascadeDelete: true)
                .Index(t => t.Id_Venta)
                .Index(t => t.Id_Producto);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        Id_Venta = c.Int(nullable: false, identity: true),
                        Monto_Pago = c.Single(nullable: false),
                        Cambio = c.Single(nullable: false),
                        Fecha_Registro = c.DateTime(nullable: false),
                        Nombre_Cliente = c.String(),
                        Nombre_Documento = c.String(),
                    })
                .PrimaryKey(t => t.Id_Venta);
            
            CreateTable(
                "dbo.Provedor",
                c => new
                    {
                        Id_Provedor = c.Int(nullable: false, identity: true),
                        Correo = c.String(),
                        Telefono = c.String(),
                        Estado = c.Boolean(nullable: false),
                        Razon_Social = c.String(),
                    })
                .PrimaryKey(t => t.Id_Provedor);
            
            CreateTable(
                "dbo.Tipo_Producto",
                c => new
                    {
                        Id_Tipo_Producto = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id_Tipo_Producto);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCompra", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.Producto", "Id_Tipo", "dbo.Tipo_Producto");
            DropForeignKey("dbo.Producto", "Id_Proveedor", "dbo.Provedor");
            DropForeignKey("dbo.DetalleVenta", "Id_Venta", "dbo.Venta");
            DropForeignKey("dbo.DetalleVenta", "Id_Producto", "dbo.Producto");
            DropForeignKey("dbo.DetalleCompra", "Compra_Id", "dbo.Compra");
            DropIndex("dbo.DetalleVenta", new[] { "Id_Producto" });
            DropIndex("dbo.DetalleVenta", new[] { "Id_Venta" });
            DropIndex("dbo.Producto", new[] { "Id_Tipo" });
            DropIndex("dbo.Producto", new[] { "Id_Proveedor" });
            DropIndex("dbo.DetalleCompra", new[] { "Producto_Id" });
            DropIndex("dbo.DetalleCompra", new[] { "Compra_Id" });
            DropTable("dbo.Tipo_Producto");
            DropTable("dbo.Provedor");
            DropTable("dbo.Venta");
            DropTable("dbo.DetalleVenta");
            DropTable("dbo.Producto");
            DropTable("dbo.DetalleCompra");
            DropTable("dbo.Compra");
            DropTable("dbo.Cliente");
        }
    }
}
