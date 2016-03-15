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
    public class SingleWordsController : Controller
    {
        private EnglishWebsiteContext db = new EnglishWebsiteContext();

        // GET: SingleWords
        public ActionResult Index()
        {
            return View(db.SingleWords.ToList());
        }

        // GET: SingleWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleWord singleWord = db.SingleWords.Find(id);
            if (singleWord == null)
            {
                return HttpNotFound();
            }
            return View(singleWord);
        }

        // GET: SingleWords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingleWords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Word,Note")] SingleWord singleWord)
        {
            if (ModelState.IsValid)
            {
                db.SingleWords.Add(singleWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(singleWord);
        }

        // GET: SingleWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleWord singleWord = db.SingleWords.Find(id);
            if (singleWord == null)
            {
                return HttpNotFound();
            }
            return View(singleWord);
        }

        // POST: SingleWords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Word,Note")] SingleWord singleWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singleWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(singleWord);
        }

        // GET: SingleWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleWord singleWord = db.SingleWords.Find(id);
            if (singleWord == null)
            {
                return HttpNotFound();
            }
            return View(singleWord);
        }

        // POST: SingleWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SingleWord singleWord = db.SingleWords.Find(id);
            db.SingleWords.Remove(singleWord);
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
