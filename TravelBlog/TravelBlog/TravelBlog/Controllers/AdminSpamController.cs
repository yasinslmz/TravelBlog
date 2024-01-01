using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;

namespace TravelBlog.Controllers
{
    public class AdminSpamController : Controller
    {
        DataContext db= new DataContext();
        // GET: AdminSpam
        public ActionResult Index()
        {
            // Veritabanındaki IsSpam değeri true olan blog sayısını al
            int spamBlogCount = db.Blog.Count(b => b.IsSpam);

            // Veritabanındaki IsSpam değeri true olan blogları liste olarak al
            var spamBlogs = db.Blog.Where(b => b.IsSpam).ToList();

            // Verileri view'e taşı
            ViewBag.SpamBlogCount = spamBlogCount;
            return View(spamBlogs);
        }
    }
}