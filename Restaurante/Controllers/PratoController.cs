﻿using System;
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
    public class PratosController : Controller
    {
        dbWebRestaurante db = new dbWebRestaurante();

        // GET: Pratos
        public ActionResult Index()
        {
            //var pratos = db.Pratos.Include(p => p.Nome);
            return View(db.Pratos.ToList());
        }

        // GET: Pratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Pratos/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteID = new SelectList(db.Pratos, "ID", "Nome", "Ativo");
            return View();
        }

        // POST: Pratos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,Nome,Preco,Ativo")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                // prato.datacadastro = DateTime.Now; 
                db.Pratos.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prato);
        }

        // GET: Pratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.PratoID = new SelectList(db.Pratos, "ID", "Nome", "Ativo", prato);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Nome,Preco,Ativo")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prato);
        }

        // POST: Pratos/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search([Bind(Include = "ID,Nome,RestauranteID,Preco")] Prato pesquisaPrato)
        {
            List<Prato> pratos;
            if (pesquisaPrato == null || string.IsNullOrEmpty(pesquisaPrato.Nome))
                pratos = db.Pratos.ToList();
            else
                pratos = (from r in db.Pratos where r.Nome.Contains(pesquisaPrato.Nome) select r).ToList();

            return Json(pratos);

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