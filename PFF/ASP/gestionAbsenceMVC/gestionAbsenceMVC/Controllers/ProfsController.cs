using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gestionAbsenceMVC.Models;

namespace gestionAbsenceMVC.Controllers
{
    public class ProfsController : Controller
    {
        private GesAbsEntities6 db = new GesAbsEntities6();

        // GET: Profs
        public ActionResult Index(string search,string searchBy)
        {
            var profs = db.Profs.Include(p => p.matiere);
            if (searchBy == "Name") { var resultofSearch = db.Profs.Where(x => x.nom_P.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Gender") { var resultofSearch = db.Profs.Where(x => x.sexe_P.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Matiere") { var resultofSearch = db.Profs.Where(x => x.matiere.libelle.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            return View(profs.ToList());
        }

        // GET: Profs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // GET: Profs/Create
        public ActionResult Create()
        {
            ViewBag.id_M = new SelectList(db.matieres, "id_M", "libelle");
            return View();
        }

        // POST: Profs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_P,nom_P,prenom_P,sexe_P,id_M")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Profs.Add(prof);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_M = new SelectList(db.matieres, "id_M", "libelle", prof.id_M);
            return View(prof);
        }

        // GET: Profs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_M = new SelectList(db.matieres, "id_M", "libelle", prof.id_M);
            return View(prof);
        }

        // POST: Profs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_P,nom_P,prenom_P,sexe_P,id_M")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_M = new SelectList(db.matieres, "id_M", "libelle", prof.id_M);
            return View(prof);
        }

        // GET: Profs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // POST: Profs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prof prof = db.Profs.Find(id);
            db.Profs.Remove(prof);
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
