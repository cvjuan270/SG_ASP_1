using SG_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_ASP_1.Controllers
{
    public class MedicinaController : Controller
    {
        private SG_ASP_1Context db = new SG_ASP_1Context();
        // GET: Medicina
        [Authorize(Roles = "Medicina,Admin")]
        public ActionResult MedicinaCreate (int Id)
        {
            ViewBag.AtenId = Id;
            var aten = db.Atenciones.Find(Id);
            var Medi = new MedicinaCreateViewModel();
            Medi.AtenId = aten.Id;
            Medi.TipExa = aten.TipExa;
            Medi.NomApe = aten.NomApe;
            Medi.DocIde = aten.DocIde;
            Medi.Empres = aten.Empres;
            Medi.Medico = aten.Medico;
            /**/
            Medi.HorIng = TimeSpan.Parse(DateTime.Now.ToLongTimeString());
            Medi.HorSal = TimeSpan.Parse(DateTime.Now.ToLongTimeString());
            /**/
            Medi.FecApt = DateTime.Parse(DateTime.Now.ToShortDateString());
            Medi.FecEnv = DateTime.Parse(DateTime.Now.ToShortDateString());
            /*/*/
            //ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", atenciones.Medico);
            ViewBag.Medico = new SelectList(db.Medicos, "Medico", "Medico", Medi.Medico);
            return View(Medi);
        }

        [HttpPost]
        [Authorize(Roles = "Medicina,Admin")]
        public ActionResult MedicinaCreate(MedicinaCreateViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Medicina med = new Medicina();
                med.AtenId = model.AtenId;
                med.HorIng = model.HorIng;
                med.HorSal = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                med.Medico = model.Medico;
                med.Aptitu = model.Aptitu;
                med.FecApt = model.FecApt;
                med.FecEnv = model.FecEnv;
                med.Observ = model.Observ;
                med.Coment = model.Coment;
                med.UserName = HttpContext.User.Identity.Name;
                db.Medicina.Add(med);
                db.SaveChanges();

                if (model.interconsultas!=null)
                {
                    foreach (var item in model.interconsultas)
                    {
                        var inte = new Interconsulta();
                        inte.AtenId = model.AtenId;
                        inte.IntCon = item.IntCon;
                        inte.UserName = HttpContext.User.Identity.Name;
                        db.Interconsulta.Add(inte);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "Atenciones");

            }
            return View(model);
        }

        public ActionResult MedicinaDetails(int Id) 
        {
            var atenciones = db.Atenciones.Find(Id);
            //ViewBag.Medicina = atenciones.Medicina;
            return View(atenciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (true)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}