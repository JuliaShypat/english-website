using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnglishWebsite.DAL;
using EnglishWebsite.Models;

namespace EnglishWebsite.Controllers
{
    public class TranslationsController : Controller
    {
        private EnglishWebsiteContext db = new EnglishWebsiteContext();

        // GET: Translations
        public ActionResult Index()
        {
            var translations = db.Translations.Include(t => t.Language).Include(t => t.SingleWord);
            return View(translations.ToList());
        }

        // GET: Translations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            return View(translation);
        }

        // GET: Translations/Create
        public ActionResult Create()
        {
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName");
            ViewBag.SingleWordID = new SelectList(db.SingleWords, "ID", "Word");
            return View();
        }

        // POST: Translations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TranslationID,SingleWordID,LanguageID,Text,Priority")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Translations.Add(translation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", translation.LanguageID);
            ViewBag.SingleWordID = new SelectList(db.SingleWords, "ID", "Word", translation.SingleWordID);
            return View(translation);
        }

        // GET: Translations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", translation.LanguageID);
            ViewBag.SingleWordID = new SelectList(db.SingleWords, "ID", "Word", translation.SingleWordID);
            return View(translation);
        }

        // POST: Translations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TranslationID,SingleWordID,LanguageID,Text,Priority")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(translation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "LanguageName", translation.LanguageID);
            ViewBag.SingleWordID = new SelectList(db.SingleWords, "ID", "Word", translation.SingleWordID);
            return View(translation);
        }

        // GET: Translations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Translation translation = db.Translations.Find(id);
            if (translation == null)
            {
                return HttpNotFound();
            }
            return View(translation);
        }

        // POST: Translations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Translation translation = db.Translations.Find(id);
            db.Translations.Remove(translation);
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
