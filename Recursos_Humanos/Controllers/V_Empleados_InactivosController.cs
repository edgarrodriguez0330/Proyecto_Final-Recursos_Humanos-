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
    public class V_Empleados_InactivosController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: V_Empleados_Inactivos
        public ActionResult Index()
        {
            return View(db.V_Empleados_Inactivos.ToList());
        }

        // GET: V_Empleados_Inactivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Inactivos v_Empleados_Inactivos = db.V_Empleados_Inactivos.Find(id);
            if (v_Empleados_Inactivos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Inactivos);
        }

        // GET: V_Empleados_Inactivos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_Empleados_Inactivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] V_Empleados_Inactivos v_Empleados_Inactivos)
        {
            if (ModelState.IsValid)
            {
                db.V_Empleados_Inactivos.Add(v_Empleados_Inactivos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_Empleados_Inactivos);
        }

        // GET: V_Empleados_Inactivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Inactivos v_Empleados_Inactivos = db.V_Empleados_Inactivos.Find(id);
            if (v_Empleados_Inactivos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Inactivos);
        }

        // POST: V_Empleados_Inactivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] V_Empleados_Inactivos v_Empleados_Inactivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_Empleados_Inactivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_Empleados_Inactivos);
        }

        // GET: V_Empleados_Inactivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Inactivos v_Empleados_Inactivos = db.V_Empleados_Inactivos.Find(id);
            if (v_Empleados_Inactivos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Inactivos);
        }

        // POST: V_Empleados_Inactivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            V_Empleados_Inactivos v_Empleados_Inactivos = db.V_Empleados_Inactivos.Find(id);
            db.V_Empleados_Inactivos.Remove(v_Empleados_Inactivos);
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
