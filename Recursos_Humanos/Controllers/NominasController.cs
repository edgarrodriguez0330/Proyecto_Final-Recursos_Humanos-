using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recursos_Humanos;


namespace Recursos_Humanos.Controllers
{
    public class NominasController : Controller
    {
        private Recursos_HumanosEntities db = new Recursos_HumanosEntities();

        // GET: Nominas
        public ActionResult Index()
        {
            //var Monto_Total = db.Empleados.SqlQuery("select SUM(Salario) from Empleados where Estatus = 1").ToList();

            /*using (var con = new EntityConnection("name=Recursos_HumanosEntities"))
            {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT salario from Empleados";
                Dictionary<int, string> dict = new Dictionary<int, string>();
                using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection))
                {
                    while (rdr.Read())
                    {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetString(1);
                        dict.Add(a, b);
                    }
                }
            }*/
            

            return View(db.Nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            string fecha = string.Format("{0:d}", DateTime.Now.Year);
            string mes = string.Format("{0:d}", DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture));
            

            decimal suma;

            string sql = "select SUM(Salario) from Empleados where Estatus = 1";
           // const string connectionString = "data source=EDGAR-PC;initial catalog=Recursos_Humanos;user id=sa;password=123;MultipleActiveResultSets=True;App=EntityFramework&quot";
            const string connectionString = "data source=DESKTOP-UA2BO3M\\MYSQLSERVER;initial catalog=Recursos_Humanos;Integrated Security=true;MultipleActiveResultSets=True;App=EntityFramework&quot";

            //const string ConnectionString = "Recursos_HumanosEntities";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);

                suma = Convert.ToDecimal(cmd.ExecuteScalar());

            }


            var model = new Nominas();
            model.Ano = fecha;
            model.Mes = mes;
            model.Monto_Total = suma;

            return View(model);
            
        }

        // POST: Nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ano,Mes,Monto_Total")] Nominas nominas)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nominas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nominas);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ano,Mes,Monto_Total")] Nominas nominas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nominas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nominas);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nominas nominas = db.Nominas.Find(id);
            if (nominas == null)
            {
                return HttpNotFound();
            }
            return View(nominas);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nominas nominas = db.Nominas.Find(id);
            db.Nominas.Remove(nominas);
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
