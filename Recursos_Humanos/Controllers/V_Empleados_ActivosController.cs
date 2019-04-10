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
    public class V_Empleados_ActivosController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: V_Empleados_Activos
        public ActionResult Index()
        {
            return View(db.V_Empleados_Activos.ToList());
        }

        // GET: V_Empleados_Activos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Activos v_Empleados_Activos = db.V_Empleados_Activos.Find(id);
            if (v_Empleados_Activos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Activos);
        }

        // GET: V_Empleados_Activos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_Empleados_Activos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] V_Empleados_Activos v_Empleados_Activos)
        {
            if (ModelState.IsValid)
            {
                db.V_Empleados_Activos.Add(v_Empleados_Activos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_Empleados_Activos);
        }

        // GET: V_Empleados_Activos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Activos v_Empleados_Activos = db.V_Empleados_Activos.Find(id);
            if (v_Empleados_Activos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Activos);
        }

        // POST: V_Empleados_Activos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] V_Empleados_Activos v_Empleados_Activos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_Empleados_Activos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_Empleados_Activos);
        }

        // GET: V_Empleados_Activos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Empleados_Activos v_Empleados_Activos = db.V_Empleados_Activos.Find(id);
            if (v_Empleados_Activos == null)
            {
                return HttpNotFound();
            }
            return View(v_Empleados_Activos);
        }

        // POST: V_Empleados_Activos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            V_Empleados_Activos v_Empleados_Activos = db.V_Empleados_Activos.Find(id);
            db.V_Empleados_Activos.Remove(v_Empleados_Activos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

        public ActionResult Buscar(String Nombre)
        {
            var employee = from e in db.V_Empleados_Activos.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(Nombre)))
            {
           

                employee = employee.Where(s => s.Nombre.Equals(Nombre));
            }
            employee = employee.OrderBy(s => s.Nombre);
            return View(employee);

        }

        public ActionResult Buscar_Departamento(String search)
        {
            var employee = from e in db.V_Empleados_Activos.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(search)))
            {
               int departamento = int.Parse(search);

                employee = employee.Where(s => s.Departamento.Equals(departamento));
            }
            employee = employee.OrderBy(s => s.Departamento);
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
