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
    public class Reporte_Entrada_EmpleadosController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: Reporte_Entrada_Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(empleados.ToList());
        }

        // GET: Reporte_Entrada_Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Reporte_Entrada_Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nombre");
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nombre");
            return View();
        }

        // POST: Reporte_Entrada_Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nombre", empleados.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.Departamento);
            return View(empleados);
        }

        // GET: Reporte_Entrada_Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nombre", empleados.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.Departamento);
            return View(empleados);
        }

        // POST: Reporte_Entrada_Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo_Empleado,Nombre,Apellido,Telefono,Departamento,Cargo,Fecha_Ingreso,Salario,Estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nombre", empleados.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nombre", empleados.Departamento);
            return View(empleados);
        }

        // GET: Reporte_Entrada_Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Reporte_Entrada_Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(String search)
        {
            var employee = from e in db.Empleados.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(search)))
            {
                DateTime newFecha = DateTime.Parse(search);

                employee = employee.Where(s => s.Fecha_Ingreso.Equals(newFecha));
            }
            employee = employee.OrderBy(s => s.Fecha_Ingreso);
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
