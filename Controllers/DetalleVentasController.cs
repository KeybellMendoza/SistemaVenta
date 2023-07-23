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
    public class DetalleVentasController : Controller
    {
        private SistemaVentaContext db = new SistemaVentaContext();

        // GET: DetalleVentas
        public ActionResult Index()
        {
            var detalleVentas = db.DetalleVentas.Include(d => d.Producto).Include(d => d.Venta);
            return View(detalleVentas.ToList());
        }

        // GET: DetalleVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Producto = new SelectList(db.Productoes, "Id_Producto", "Nombre");
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id_Venta", "Nombre_Cliente");
            return View();
        }

        // POST: DetalleVentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_DetalleVenta,Id_Venta,Id_Producto,Precio_Venta,Cantidad,Sub_Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.DetalleVentas.Add(detalleVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Producto = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleVenta.Id_Producto);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id_Venta", "Nombre_Cliente", detalleVenta.Id_Venta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Producto = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleVenta.Id_Producto);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id_Venta", "Nombre_Cliente", detalleVenta.Id_Venta);
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_DetalleVenta,Id_Venta,Id_Producto,Precio_Venta,Cantidad,Sub_Total")] DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Producto = new SelectList(db.Productoes, "Id_Producto", "Nombre", detalleVenta.Id_Producto);
            ViewBag.Id_Venta = new SelectList(db.Ventas, "Id_Venta", "Nombre_Cliente", detalleVenta.Id_Venta);
            return View(detalleVenta);
        }

        // GET: DetalleVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleVenta detalleVenta = db.DetalleVentas.Find(id);
            if (detalleVenta == null)
            {
                return HttpNotFound();
            }
            return View(detalleVenta);
        }

        // POST: DetalleVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleVenta detalleVenta = db.DetalleVentas.Find(id);
            db.DetalleVentas.Remove(detalleVenta);
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
