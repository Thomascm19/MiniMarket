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
    public class InformacionsController : Controller
    {
        private Entities db = new Entities();

        // GET: Informacions
        public ActionResult Index()
        {
            return View(db.Informacion.ToList());
        }

        // GET: Informacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacion informacion = db.Informacion.Find(id);
            if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(informacion);
        }

        // GET: Informacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Informacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nit,Nombre,Telefono,Email,Direccion")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                db.Informacion.Add(informacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informacion);
        }

        // GET: Informacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacion informacion = db.Informacion.Find(id);
            if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(informacion);
        }

        // POST: Informacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nit,Nombre,Telefono,Email,Direccion")] Informacion informacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informacion);
        }

        // GET: Informacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacion informacion = db.Informacion.Find(id);
            if (informacion == null)
            {
                return HttpNotFound();
            }
            return View(informacion);
        }

        // POST: Informacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informacion informacion = db.Informacion.Find(id);
            db.Informacion.Remove(informacion);
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
