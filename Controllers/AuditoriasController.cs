﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SG_ASP_1.Models;

namespace SG_ASP_1.Controllers
{
    public class AuditoriasController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();

        // GET: Auditorias
        public ActionResult Index()
        {
            var auditoria = db.Auditoria.Include(a => a.Atenciones);
            return View(auditoria.ToList());
        }

        // GET: Auditorias/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ate = db.Atenciones.Find(Id);
            var aud = db.Auditoria.Where(c=>c.AtenId ==Id);
            Auditoria auditoria = new Auditoria();
            if (aud == null)
            {
                return HttpNotFound();
            }
            foreach (var item in aud)
            {
                auditoria = item;
            }
            return View(auditoria);
        }

        // GET: Auditorias/Create
        public ActionResult Create(int Id)
        {
            var aten = db.Atenciones.Find(Id);
            var audi = new Auditoria();
            audi.AtenId = aten.Id;
            audi.Medico = aten.Medico;
            audi.HorAud = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            audi.FecAud = DateTime.Parse(DateTime.Now.ToShortDateString());

            ViewBag.AtenId = Id;
            ViewBag.DocIde = aten.DocIde;
            ViewBag.NomApe = aten.NomApe;
            ViewBag.Empres = aten.Empres;

            ViewBag.Medico = new SelectList(db.Medicos, "Id", "Medico");
            return View(audi);
        }

        // POST: Auditorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AtenId,ExaCom,ExaCom1,DatInc,DatInc1,AptErr,AptErr1,FaFiMe,FaFiMe1,FaFiPa,FaFiPa1,Restri,Restri1,Contro,Contro1,Diagno,Diagno1,ErrLle,ErrLle1,ObNoRe,EmSnOb,EmSnOb1,OmiInt,OmiInt1,HorAud,FecAud,Alerta,UserName,Medico")] Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(auditoria.Medico))
                {
                    auditoria.Medico = "SM";
                }
                db.Auditoria.Add(auditoria);
                db.SaveChanges();
                return RedirectToAction("Index","Atenciones");
            }

            ViewBag.AtenId = new SelectList(db.Atenciones, "Id", "Local0", auditoria.AtenId);
            return View(auditoria);
        }

        // GET: Auditorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtenId = new SelectList(db.Atenciones, "Id", "Local0", auditoria.AtenId);
            return View(auditoria);
        }

        // POST: Auditorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtenId,ExaCom,ExaCom1,DatInc,DatInc1,AptErr,AptErr1,FaFiMe,FaFiMe1,FaFiPa,FaFiPa1,Restri,Restri1,Contro,Contro1,Diagno,Diagno1,ErrLle,ErrLle1,ObNoRe,EmSnOb,EmSnOb1,OmiInt,OmiInt1,HorAud,FecAud,Alerta,UserName,Medico")] Auditoria auditoria)
        {
            if (ModelState.IsValid)
            {
                auditoria.UserName = HttpContext.User.Identity.Name;
                db.Entry(auditoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Atenciones");
            }
            ViewBag.AtenId = new SelectList(db.Atenciones, "Id", "Local0", auditoria.AtenId);
            return View(auditoria);
        }

        // GET: Auditorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditoria auditoria = db.Auditoria.Find(id);
            if (auditoria == null)
            {
                return HttpNotFound();
            }
            return View(auditoria);
        }

        // POST: Auditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditoria auditoria = db.Auditoria.Find(id);
            db.Auditoria.Remove(auditoria);
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

        public ActionResult Atenciones() 
        {
            return RedirectToAction("Index", "Atenciones");
        }
    }
}
