using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recursos_Humanos;

namespace Recursos_Humanos.Controllers
{
    public class VacaionesController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: Vacaiones
        public ActionResult Index()
        {
            var vacaiones = db.Vacaiones.Include(v => v.Empleados);
            return View(vacaiones.ToList());
        }

        // GET: Vacaiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaiones vacaiones = db.Vacaiones.Find(id);
            if (vacaiones == null)
            {
                return HttpNotFound();
            }
            return View(vacaiones);
        }

        // GET: Vacaiones/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: Vacaiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empleado_id,Desde,Hasta,Correspondiente_Ano,Comentarios")] Vacaiones vacaiones)
        {
            if (ModelState.IsValid)
            {
                db.Vacaiones.Add(vacaiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", vacaiones.Empleado_id);
            return View(vacaiones);
        }

        // GET: Vacaiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaiones vacaiones = db.Vacaiones.Find(id);
            if (vacaiones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", vacaiones.Empleado_id);
            return View(vacaiones);
        }

        // POST: Vacaiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empleado_id,Desde,Hasta,Correspondiente_Ano,Comentarios")] Vacaiones vacaiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", vacaiones.Empleado_id);
            return View(vacaiones);
        }

        // GET: Vacaiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacaiones vacaiones = db.Vacaiones.Find(id);
            if (vacaiones == null)
            {
                return HttpNotFound();
            }
            return View(vacaiones);
        }

        // POST: Vacaiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vacaiones vacaiones = db.Vacaiones.Find(id);
            db.Vacaiones.Remove(vacaiones);
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
