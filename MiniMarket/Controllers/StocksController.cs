using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniMarket;

namespace MiniMarket.Controllers
{
    public class StocksController : Controller
    {
        private Entities db = new Entities();

        // GET: Stocks
        public ActionResult Index()
        {
            var stock = db.Stock.Include(s => s.Cliente).Include(s => s.Producto).Include(s => s.Proveedor);
            return View(stock.ToList());
        }

        // GET: Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Cliente = new SelectList(db.Cliente, "Codigo_Cliente", "Nombre");
            ViewBag.Codigo_Producto = new SelectList(db.Producto, "Codigo_Producto", "Nombre");
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre");
            return View();
        }

        // POST: Stocks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Cliente,Codigo_Producto,Codigo_Proveedor,Fecha,Cantidad")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Cliente = new SelectList(db.Cliente, "Codigo_Cliente", "Nombre", stock.Codigo_Cliente);
            ViewBag.Codigo_Producto = new SelectList(db.Producto, "Codigo_Producto", "Nombre", stock.Codigo_Producto);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre", stock.Codigo_Proveedor);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Cliente = new SelectList(db.Cliente, "Codigo_Cliente", "Nombre", stock.Codigo_Cliente);
            ViewBag.Codigo_Producto = new SelectList(db.Producto, "Codigo_Producto", "Nombre", stock.Codigo_Producto);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre", stock.Codigo_Proveedor);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Cliente,Codigo_Producto,Codigo_Proveedor,Fecha,Cantidad")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Cliente = new SelectList(db.Cliente, "Codigo_Cliente", "Nombre", stock.Codigo_Cliente);
            ViewBag.Codigo_Producto = new SelectList(db.Producto, "Codigo_Producto", "Nombre", stock.Codigo_Producto);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre", stock.Codigo_Proveedor);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stock.Find(id);
            db.Stock.Remove(stock);
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
