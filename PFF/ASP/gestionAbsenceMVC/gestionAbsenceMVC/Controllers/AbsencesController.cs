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
    public class AbsencesController : Controller
    {
        private GesAbsEntities6 db = new GesAbsEntities6();

        // GET: Absences
        public ActionResult Index(string search,string searchBy)
        {
            var absences = db.Absences.Include(a => a.Prof).Include(a => a.Stagiare);
            if (searchBy == "NameT") { var resultofSearch = db.Absences.Where(x => x.Stagiare.nom_S.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Date") { var resultofSearch = db.Absences.Where(x =>x.DateA!=null); return View(resultofSearch.ToList()); }
            if (searchBy == "NameP") { var resultofSearch = db.Absences.Where(x => x.Prof.nom_P.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Jus") { var resultofSearch = db.Absences.Where(x => x.justf.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Tyabs") { var resultofSearch = db.Absences.Where(x => x.type_Ab.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }

            return View(absences.ToList());
        }

        // GET: Absences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // GET: Absences/Create
        public ActionResult Create()
        {
            ViewBag.id_P = new SelectList(db.Profs, "id_P", "nom_P");
            ViewBag.id_S = new SelectList(db.Stagiares, "id_S", "nom_S");
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_A,DateA,type_Ab,id_S,id_P,justf")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Absences.Add(absence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_P = new SelectList(db.Profs, "id_P", "nom_P", absence.id_P);
            ViewBag.id_S = new SelectList(db.Stagiares, "id_S", "nom_S", absence.id_S);
            return View(absence);
        }

        // GET: Absences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_P = new SelectList(db.Profs, "id_P", "nom_P", absence.id_P);
            ViewBag.id_S = new SelectList(db.Stagiares, "id_S", "nom_S", absence.id_S);
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_A,DateA,type_Ab,id_S,id_P,justf")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(absence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_P = new SelectList(db.Profs, "id_P", "nom_P", absence.id_P);
            ViewBag.id_S = new SelectList(db.Stagiares, "id_S", "nom_S", absence.id_S);
            return View(absence);
        }

        // GET: Absences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Absence absence = db.Absences.Find(id);
            if (absence == null)
            {
                return HttpNotFound();
            }
            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Absence absence = db.Absences.Find(id);
            db.Absences.Remove(absence);
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
