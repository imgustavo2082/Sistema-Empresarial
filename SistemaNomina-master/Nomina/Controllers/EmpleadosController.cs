using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Nomina.Models;

namespace Nomina.Controllers
{
    public class EmpleadosController : Controller
    {
        private Nominacontext db = new Nominacontext();

        // GET: Empleados
        public ActionResult Index()
        {
            var cargos = (from emp in db.empleados join carg in db.cargos on emp.cargo equals carg.cargo select new { cargo = carg.cargo });
            var mostrarcargos = new SelectList(cargos).ToList();
            ViewBag.muestra = mostrarcargos;
            return View(db.empleados.ToList());


        }


        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            var cargos = (from cargos2 in db.cargos select cargos2).ToList();
            var listacargos = new SelectList(cargos, "cargo", "cargo");
            ViewBag.Cargos = listacargos;

            var departamentos = (from dep in db.departamentos select dep).ToList();
            var listadepartamentos = new SelectList(departamentos, "departamento", "departamento");
            ViewBag.departamentos = listadepartamentos;

            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,apellido,telefono,departamento,cargo,fechaentrada,salario,estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            var cargos = (from cargos2 in db.cargos select cargos2).ToList();
            var listacargos = new SelectList(cargos, "cargo", "cargo");
            ViewBag.Cargos = listacargos;

            var departamentos = (from dep in db.departamentos select dep).ToList();
            var listadepartamentos = new SelectList(departamentos, "cargo", "departamento");
            ViewBag.departamentos = listadepartamentos;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,apellido,telefono,departamento,cargo,fechaentrada,salario,estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados empleados = db.empleados.Find(id);
            db.empleados.Remove(empleados);
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

        public ActionResult totalizar()
        {
            Nullable<decimal> montototal = (from emp in db.empleados select (long)emp.salario).Sum();

            ViewBag.total = montototal;

            return View();
        }

        public async Task<ActionResult> EmpleadoActivos(String SearchString, String rd)
        {
            IQueryable<string> nomQuery = from c in db.empleados
                                          orderby c.nombre
                                          select c.nombre;

            var contact = from e in db.empleados where e.estado == "Activo" select e;

            if (!string.IsNullOrEmpty(SearchString) && rd == "Nombre")
            {
                contact = contact.Where(s => s.nombre.Contains(SearchString));
            }else if (!string.IsNullOrEmpty(SearchString) && rd == "Departamento")
            {
                contact = contact.Where(s => s.departamento.Contains(SearchString));
            }

            var con = new Empleados
            {
                empleados = await contact.ToListAsync()
            };

            return View(con);
        }

        [HttpPost]
        public string EmpleadoActivos(string searchString, bool notused)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public async Task<ActionResult> EmpleadoInactivos()
        {
            var listado = from e in db.empleados where e.estado == "Inactivo" select e;
            return View(await listado.ToListAsync());
        }

    }
}
