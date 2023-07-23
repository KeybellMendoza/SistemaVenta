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
    public class ProductoesController : Controller
    {
        private SistemaVentaContext db = new SistemaVentaContext();

        // GET: Productoes
        public ActionResult Index()
        {
            var productoes = db.Productoes.Include(p => p.Provedor).Include(p => p.Tipo_Producto);
            return View(productoes.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Proveedor = new SelectList(db.Provedors, "Id_Provedor", "Correo");
            ViewBag.Id_Tipo = new SelectList(db.Tipo_Producto, "Id_Tipo_Producto", "Descripcion");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Producto,Id_Proveedor,Nombre,Cantidad,Fecha_Inventario,Id_Tipo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Productoes.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Proveedor = new SelectList(db.Provedors, "Id_Provedor", "Correo", producto.Id_Proveedor);
            ViewBag.Id_Tipo = new SelectList(db.Tipo_Producto, "Id_Tipo_Producto", "Descripcion", producto.Id_Tipo);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Proveedor = new SelectList(db.Provedors, "Id_Provedor", "Correo", producto.Id_Proveedor);
            ViewBag.Id_Tipo = new SelectList(db.Tipo_Producto, "Id_Tipo_Producto", "Descripcion", producto.Id_Tipo);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Producto,Id_Proveedor,Nombre,Cantidad,Fecha_Inventario,Id_Tipo")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Proveedor = new SelectList(db.Provedors, "Id_Provedor", "Correo", producto.Id_Proveedor);
            ViewBag.Id_Tipo = new SelectList(db.Tipo_Producto, "Id_Tipo_Producto", "Descripcion", producto.Id_Tipo);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productoes.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productoes.Find(id);
            db.Productoes.Remove(producto);
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
