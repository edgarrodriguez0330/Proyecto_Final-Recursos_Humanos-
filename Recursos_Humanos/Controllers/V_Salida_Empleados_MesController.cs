﻿using System;
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
    public class V_Salida_Empleados_MesController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: V_Salida_Empleados_Mes
        public ActionResult Index()
        {
            var salida_Empleados = db.Salida_Empleados.Include(s => s.Empleados);
            return View(salida_Empleados.ToList());
        }

        // GET: V_Salida_Empleados_Mes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_Empleados.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleados);
        }

        // GET: V_Salida_Empleados_Mes/Create
        public ActionResult Create()
        {
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: V_Salida_Empleados_Mes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empleado_id,Tipo_Salida,Fecha_Salida")] Salida_Empleados salida_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Salida_Empleados.Add(salida_Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", salida_Empleados.Empleado_id);
            return View(salida_Empleados);
        }

        // GET: V_Salida_Empleados_Mes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_Empleados.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", salida_Empleados.Empleado_id);
            return View(salida_Empleados);
        }

        // POST: V_Salida_Empleados_Mes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empleado_id,Tipo_Salida,Fecha_Salida")] Salida_Empleados salida_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empleado_id = new SelectList(db.Empleados, "Id", "Nombre", salida_Empleados.Empleado_id);
            return View(salida_Empleados);
        }

        // GET: V_Salida_Empleados_Mes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida_Empleados salida_Empleados = db.Salida_Empleados.Find(id);
            if (salida_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(salida_Empleados);
        }

        // POST: V_Salida_Empleados_Mes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salida_Empleados salida_Empleados = db.Salida_Empleados.Find(id);
            db.Salida_Empleados.Remove(salida_Empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buscar(String search)
        {
            var employee = from e in db.Salida_Empleados.ToList()
                           select e;

            if ((!String.IsNullOrEmpty(search)))
            {
                DateTime newFecha = DateTime.Parse(search);

                employee = employee.Where(s => s.Fecha_Salida.Equals(newFecha));
            }
            employee = employee.OrderBy(s => s.Fecha_Salida);
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
