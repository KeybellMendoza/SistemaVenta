using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVenta.Data;
using SistemaVenta.Models;

namespace SistemaVenta.Controllers
{
    public class DetalleComprasController : Controller
    {
        private SistemaVentaContext db = new SistemaVentaContext();

        // GET: DetalleCompras
        public ActionResult Index()
        {
            var detalleCompras = db.DetalleCompras.Include(d => d.Compra).Include(d => d.Producto);
            return View(detalleCompras.ToList());
        }

        // GET: DetalleCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Create
        public ActionResult Create()
        {
            ViewBag.Compra_Id = new SelectList(db.Compras, "Id_Compra", "Id_Compra");
            ViewBag.Producto_Id = new SelectList(db.Productoes, "Id_Producto", "Nombre");
            return View();
        }

        // POST: DetalleCompras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_DetalleCompra,Compra_Id,Producto_Id,Precio_Compra,Precio_Venta,Cantidad,Sub_Total")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCompras.Add(detalleCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Compra_Id = new SelectList(db.Compras, "Id_Compra", "Id_Compra", detalleCompra.Compra_Id);
            ViewBag.Producto_Id = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleCompra.Producto_Id);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Compra_Id = new SelectList(db.Compras, "Id_Compra", "Id_Compra", detalleCompra.Compra_Id);
            ViewBag.Producto_Id = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleCompra.Producto_Id);
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_DetalleCompra,Compra_Id,Producto_Id,Precio_Compra,Precio_Venta,Cantidad,Sub_Total")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Compra_Id = new SelectList(db.Compras, "Id_Compra", "Id_Compra", detalleCompra.Compra_Id);
            ViewBag.Producto_Id = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleCompra.Producto_Id);
            return View(detalleCompra);
        }

        // GET: DetalleCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // POST: DetalleCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCompra detalleCompra = db.DetalleCompras.Find(id);
            db.DetalleCompras.Remove(detalleCompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
