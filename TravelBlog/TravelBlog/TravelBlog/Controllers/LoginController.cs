using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using TravelBlog.Entity;
using TravelBlog.Models;
namespace TravelBlog.Controllers
{
    public class LoginController : Controller
    {
        DataContext db=new DataContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // POST: Login
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                // Eğer model doğrulaması geçerliyse
                user.createTime = DateTime.Now;
                user.RoleId = 2; // Kullanıcı rolü için 2 değerini kullanıyoruz

                if(user.Name!=null && user.Surname != null && user.password != null && user.userName != null)
                {

                    db.User.Add(user);
                    db.SaveChanges();

                    // Başarılı bir şekilde kullanıcı eklendikten sonra bir view veya başka bir işlem döndürebilirsiniz
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
        // POST: Login
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var loginUser= db.User.FirstOrDefault(x=>x.email==user.email && x.password==user.password && !x.IsDelete);
                if(loginUser != null)
                {
                    // Giriş başarılı olduğunda kullanıcı bilgilerini Session'a sakla
                    Session["LoggedInUser"] = loginUser;
                    FormsAuthentication.SetAuthCookie(user.email, false);//Giriş Yapma işlemi

                    // Başarılı bir şekilde giriş yaptıktan sonra bir view veya başka bir işlem döndürebilirsiniz
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ViewBag.ErrorMessage = "Kullanıcı bulunamadı veya giriş bilgileri hatalı.";

                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            // Oturumu sonlandır
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}