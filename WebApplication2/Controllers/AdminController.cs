using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        
        private signEntities3 db = new signEntities3();
        public ActionResult Index()
        { 
            return View();
        }
        // GET: Admin
        public ActionResult UsersIndex()
        {
            return View(db.Users.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult UsersDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Admin/Create
        public ActionResult UsersCreate()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersCreate([Bind(Include = "Userid,UserName,UserLastName,UserEmail,UserPassword")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("UsersIndex");
            }

            return View(users);
        }

        // GET: Admin/Edit/5
        public ActionResult UsersEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UsersEdit([Bind(Include = "Userid,UserName,UserLastName,UserEmail,UserPassword")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UsersIndex");
            }
            return View(users);
        }

        // GET: Admin/Delete/5
        public ActionResult UsersDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("UsersDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UsersDeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("UsersIndex");
        }

        // HABERLER----------
        public ActionResult haberIndex()
        {
            return View(db.haber.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult haberDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            haber haber = db.haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // GET: Admin/Create
        public ActionResult haberCreate()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult haberCreate([Bind(Include = "id,baslik,icerik")] haber haber)
        {
            if (ModelState.IsValid)
            {
                db.haber.Add(haber);
                db.SaveChanges();
                return RedirectToAction("haberIndex");
            }

            return View(haber);
        }

        // GET: Admin/Edit/5
        public ActionResult haberEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            haber haber = db.haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult haberEdit([Bind(Include = "id,baslik,icerik")] haber haber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(haber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("haberIndex");
            }
            return View(haber);
        }

        // GET: Admin/Delete/5
        public ActionResult haberDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            haber haber = db.haber.Find(id);
            if (haber == null)
            {
                return HttpNotFound();
            }
            return View(haber);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("haberDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult haberDeleteConfirmed(int id)
        {
            haber haber = db.haber.Find(id);
            db.haber.Remove(haber);
            db.SaveChanges();
            return RedirectToAction("haberIndex");
        }

    }
}
