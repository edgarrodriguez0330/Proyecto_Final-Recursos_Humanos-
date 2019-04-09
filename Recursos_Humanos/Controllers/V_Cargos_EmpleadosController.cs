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
    public class V_Cargos_EmpleadosController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: V_Cargos_Empleados
        public ActionResult Index()
        {
            return View(db.V_Cargos_Empleados.ToList());
        }

        // GET: V_Cargos_Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Cargos_Empleados v_Cargos_Empleados = db.V_Cargos_Empleados.Find(id);
            if (v_Cargos_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(v_Cargos_Empleados);
        }

        // GET: V_Cargos_Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_Cargos_Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] V_Cargos_Empleados v_Cargos_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.V_Cargos_Empleados.Add(v_Cargos_Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_Cargos_Empleados);
        }

        // GET: V_Cargos_Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Cargos_Empleados v_Cargos_Empleados = db.V_Cargos_Empleados.Find(id);
            if (v_Cargos_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(v_Cargos_Empleados);
        }

        // POST: V_Cargos_Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] V_Cargos_Empleados v_Cargos_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_Cargos_Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_Cargos_Empleados);
        }

        // GET: V_Cargos_Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Cargos_Empleados v_Cargos_Empleados = db.V_Cargos_Empleados.Find(id);
            if (v_Cargos_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(v_Cargos_Empleados);
        }

        // POST: V_Cargos_Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            V_Cargos_Empleados v_Cargos_Empleados = db.V_Cargos_Empleados.Find(id);
            db.V_Cargos_Empleados.Remove(v_Cargos_Empleados);
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
