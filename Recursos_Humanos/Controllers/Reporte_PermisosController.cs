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
    public class Reporte_PermisosController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: Reporte_Permisos
        public ActionResult Index()
        {
            var permisos = db.Permisos.Include(p => p.Empleados);
            return View(permisos.ToList());
        }

        // GET: Reporte_Permisos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = db.Permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // GET: Reporte_Permisos/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: Reporte_Permisos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empleado_id,Desde,Hasta,Comentarios")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Permisos.Add(permisos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", permisos.Empleado_id);
            return View(permisos);
        }

        // GET: Reporte_Permisos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = db.Permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", permisos.Empleado_id);
            return View(permisos);
        }

        // POST: Reporte_Permisos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empleado_id,Desde,Hasta,Comentarios")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", permisos.Empleado_id);
            return View(permisos);
        }

        // GET: Reporte_Permisos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = db.Permisos.Find(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // POST: Reporte_Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permisos permisos = db.Permisos.Find(id);
            db.Permisos.Remove(permisos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(String search)
        {
            var employee = from e in db.Permisos.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(search)))
            {
                int id_Empleado = int.Parse(search);

                employee = employee.Where(s => s.Empleado_id.Equals(id_Empleado));
            }
            employee = employee.OrderBy(s => s.Empleado_id);
            return View(employee);
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
