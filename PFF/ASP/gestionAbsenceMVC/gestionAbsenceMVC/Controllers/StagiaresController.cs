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
    public class StagiaresController : Controller
    {
        private GesAbsEntities6 db = new GesAbsEntities6();

        // GET: Stagiares
        public ActionResult Index(string search,string searchBy)
        {
            var stagiares = db.Stagiares.Include(s => s.Groupe);
            if (searchBy == "Name") { var resultofSearch = db.Stagiares.Where(x => x.nom_S.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Gender") { var resultofSearch = db.Stagiares.Where(x => x.sexe_S.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            if (searchBy == "Groupe") { var resultofSearch = db.Stagiares.Where(x => x.Groupe.nom_G.StartsWith(search) || search == null); return View(resultofSearch.ToList()); }
            return View(stagiares.ToList());



        }

        // GET: Stagiares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiare stagiare = db.Stagiares.Find(id);
            if (stagiare == null)
            {
                return HttpNotFound();
            }
            return View(stagiare);
        }

        // GET: Stagiares/Create
        public ActionResult Create()
        {
            ViewBag.id_G = new SelectList(db.Groupes, "id_G", "nom_G");
            return View();
        }

        // POST: Stagiares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_S,nom_S,prenom_S,sexe_S,id_G")] Stagiare stagiare)
        {
            if (ModelState.IsValid)
            {
                db.Stagiares.Add(stagiare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_G = new SelectList(db.Groupes, "id_G", "nom_G", stagiare.id_G);
            return View(stagiare);
        }

        // GET: Stagiares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiare stagiare = db.Stagiares.Find(id);
            if (stagiare == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_G = new SelectList(db.Groupes, "id_G", "nom_G", stagiare.id_G);
            return View(stagiare);
        }

        // POST: Stagiares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_S,nom_S,prenom_S,sexe_S,id_G")] Stagiare stagiare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stagiare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_G = new SelectList(db.Groupes, "id_G", "nom_G", stagiare.id_G);
            return View(stagiare);
        }

        // GET: Stagiares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stagiare stagiare = db.Stagiares.Find(id);
            if (stagiare == null)
            {
                return HttpNotFound();
            }
            return View(stagiare);
        }

        // POST: Stagiares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stagiare stagiare = db.Stagiares.Find(id);
            db.Stagiares.Remove(stagiare);
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
