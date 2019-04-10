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
    public class V_NominasController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: V_Nominas
        public ActionResult Index()
        {
            return View(db.V_Nominas.ToList());
        }

        // GET: V_Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Nominas v_Nominas = db.V_Nominas.Find(id);
            if (v_Nominas == null)
            {
                return HttpNotFound();
            }
            return View(v_Nominas);
        }

        // GET: V_Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_Nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ano,Mes,Monto_Total")] V_Nominas v_Nominas)
        {
            if (ModelState.IsValid)
            {
                db.V_Nominas.Add(v_Nominas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_Nominas);
        }

        // GET: V_Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Nominas v_Nominas = db.V_Nominas.Find(id);
            if (v_Nominas == null)
            {
                return HttpNotFound();
            }
            return View(v_Nominas);
        }

        // POST: V_Nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ano,Mes,Monto_Total")] V_Nominas v_Nominas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_Nominas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_Nominas);
        }

        // GET: V_Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_Nominas v_Nominas = db.V_Nominas.Find(id);
            if (v_Nominas == null)
            {
                return HttpNotFound();
            }
            return View(v_Nominas);
        }

        // POST: V_Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            V_Nominas v_Nominas = db.V_Nominas.Find(id);
            db.V_Nominas.Remove(v_Nominas);
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
