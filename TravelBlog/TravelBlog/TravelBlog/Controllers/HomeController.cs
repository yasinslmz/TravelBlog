using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;
using TravelBlog.Models;
using TravelBlog.Models.ViewModel;

namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        DataContext db=new DataContext();
        public ActionResult Index()
        {
            
            var loggedInUser = Session["LoggedInUser"] as User;

            ViewBag.LoggedInUser = loggedInUser;

            var blogs = db.Blog.Include("User").ToList();
            ViewBag.Blogs = blogs;

            var topLikedBlogs = db.BlogLikeRelations
                .GroupBy(blr => blr.BlogId)
                .Select(g => new { BlogId = g.Key, LikeCount = g.Count() })
                .OrderByDescending(x => x.LikeCount)
                .ToList();

            // En çok beğeni alan ilk 5 blogun detaylarını al
            var topLikedBlogIds = topLikedBlogs.Take(5).Select(x => x.BlogId).ToList();
            var topLikedBlogDetails = db.Blog
                .Include("User")
                .Where(blog => topLikedBlogIds.Contains(blog.Id))
                .ToList();

            ViewBag.TopLikedBlogs = topLikedBlogDetails;

            // İlk 3 şehri al
            var topCities = db.City.Take(3).ToList();

            // ViewModel oluştur
            var viewModel = new CityListViewModel
            {
                TopCities = topCities,
                AllCities = db.City.ToList()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}