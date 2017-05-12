using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRestaurante.Models;

namespace WebRestaurante.Controllers
{
    public class RestaurantesController : Controller
    {
        private dbWebRestaurante db = new dbWebRestaurante();

        // GET: Restaurantes
        public ActionResult Index()
        {
            return View(db.Restaurantes.ToList());
        }

        // GET: Restaurantes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Nome,Ativo")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Restaurantes.Add(restaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurante);
        }

        // GET: Restaurantes/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Nome,Ativo")] Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Delete
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Restaurantes/Search
        [HttpPost]
        public ActionResult Search([Bind(Include = "ID,Nome,Ativo")] Restaurante pesquisaRestaurante)
        {
            List<Restaurante> restauranteS;
            if (pesquisaRestaurante == null || string.IsNullOrEmpty(pesquisaRestaurante.Nome))
                restauranteS = db.Restaurantes.ToList();
            else
                restauranteS = (from r in db.Restaurantes where r.Nome.Contains(pesquisaRestaurante.Nome) select r).ToList();

            return Json(restauranteS);

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
