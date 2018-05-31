using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
     
        
        public ActionResult Haber()
        {
            signEntities3 dbc = new signEntities3();
            haberler k1 = new haberler();
            k1.habers = dbc.haber.ToList();
            return View(k1);
        
        }

        public ActionResult iletisim()
        {
            return View();
        }
        public ActionResult Kimdir()
        {
            return View();
        }

        public ActionResult Album()
        {
            albumler k = new albumler();
            k.album = db.albumtik.ToList();
            return View(k);
        }
        public ActionResult albumetik(int? id)
        {
            albumtik album = db.albumtik.Find(id);
            return View(album);
        }
       
        public ActionResult Konser()
        {
            return View();
        }
        public ActionResult a_index()
        {
            return View();
        }
        public ActionResult Cikis()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult login()
        {
            return View();
        }
        private signEntities3 db = new signEntities3();
       



        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult register(FormCollection form)
        {
            signEntities3 db = new signEntities3();
            Users model = new Users();
            model.UserEmail = form["UserEmail"].Trim();
            model.UserName = form["UserName"].Trim();
            model.UserLastName = form["UserSurname"].Trim();
            model.UserPassword = form["UserPassword"].Trim();
            db.Users.Add(model);
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult login(Users Model, FormCollection form)
        {
            var kullanıcı = db.Users.FirstOrDefault(x => x.UserName == Model.UserName && x.UserPassword == Model.UserPassword);
            string Kul_Adi = form["UserName"].Trim();
            string Password = form["UserPassword"].Trim();
            if (Kul_Adi=="admin" && Password=="admin")
            {
                return RedirectToAction("a_index","Home");
            }
            else if (kullanıcı != null)
            {
                Session["UserName"] = kullanıcı;
                return RedirectToAction("Index", "Home");
            }
            Response.Write("<script>alert('Hatalı Giriş')</script>");
            return View();
        }
        public class albumler
        {
            public List<albumtik> album { get; set; }
        }
        public class haberler
        {
            public List<haber> habers { get; set; }
        }
    }
}