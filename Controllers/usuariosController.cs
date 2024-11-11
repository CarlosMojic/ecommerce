using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ecomerce.Models;

namespace ecomerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class usuariosController : Controller
    {
        private EmpleadosEntities db = new EmpleadosEntities();

        // GET: usuarios
        public ActionResult Index()
        {
            var usuarios = db.usuarios.Include(u => u.cargos).Include(u => u.departamentos);
            return View(usuarios.ToList());
        }

        // GET: usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // GET: usuarios/Create
        public ActionResult Create()
        {
            ViewBag.cargo_id = new SelectList(db.cargos, "cargo_id", "nombre_cargo");
            ViewBag.departamento_id = new SelectList(db.departamentos, "departamento_id", "nombre_departamento");
            return View();
        }

        // POST: usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usuario_id,nombre,apellido,correo,fecha_ingreso,departamento_id,cargo_id")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargo_id = new SelectList(db.cargos, "cargo_id", "nombre_cargo", usuarios.cargo_id);
            ViewBag.departamento_id = new SelectList(db.departamentos, "departamento_id", "nombre_departamento", usuarios.departamento_id);
            return View(usuarios);
        }

        // GET: usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo_id = new SelectList(db.cargos, "cargo_id", "nombre_cargo", usuarios.cargo_id);
            ViewBag.departamento_id = new SelectList(db.departamentos, "departamento_id", "nombre_departamento", usuarios.departamento_id);
            return View(usuarios);
        }

        // POST: usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usuario_id,nombre,apellido,correo,fecha_ingreso,departamento_id,cargo_id")] usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargo_id = new SelectList(db.cargos, "cargo_id", "nombre_cargo", usuarios.cargo_id);
            ViewBag.departamento_id = new SelectList(db.departamentos, "departamento_id", "nombre_departamento", usuarios.departamento_id);
            return View(usuarios);
        }

        // GET: usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios usuarios = db.usuarios.Find(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarios usuarios = db.usuarios.Find(id);
            db.usuarios.Remove(usuarios);
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
