using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class UserDashboardController : Controller
    {
        DataContext db=new DataContext();
        // GET: UserDashboard
        public ActionResult Index()
        {
            var loggedInUser = Session["LoggedInUser"] as User;
            ViewBag.LoggedInUser = loggedInUser;

            if(loggedInUser != null)
            {
                // Kullanıcının blogları
                var userBlogs = db.Blog.Where(b => b.UserId == loggedInUser.Id).ToList();

                // Kullanıcının beğendiği blog sayısı
                var likedBlogsCount = db.BlogLikeRelations.Count(bl => bl.UserId == loggedInUser.Id);

                // Kullanıcının hangi şehirler için blog oluşturduğu
                var citiesForBlogs = db.City
                    .Where(c => db.BlogCityRelations.Any(bc => bc.Blog.UserId == loggedInUser.Id && bc.CityId == c.Id))
                    .ToList();

                ViewBag.LikedBlogsCount = likedBlogsCount;
                ViewBag.CitiesForBlogs = citiesForBlogs.Count();

                return View(userBlogs);
            }
            else
            {   
                return RedirectToAction("Index","Login");
            }
            
            
        }
    }
}