using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;
using TravelBlog.Models;
using TravelBlog.Models.ViewModel;

namespace TravelBlog.Controllers
{
    public class BlogsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Blogs
        public ActionResult Index()
        {
            var blog = db.Blog.Include(b => b.User);
            return View(blog.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            var viewModel = new BlogCreateViewModel
            {
                Users = new SelectList(db.User, "Id", "Name"),
                Cities = new SelectList(db.City, "Id", "Name")
            };

            return View(viewModel);
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Blog nesnesini oluştur
                var blog = viewModel.Blog;

                // Diğer işlemleri gerçekleştir
                db.Blog.Add(blog);
                db.SaveChanges();

                // Blog ve City arasındaki ilişkiyi oluşturmak için yeni bir BlogCityRelations girişi ekleyin
                var blogCityRelation = new BlogCityRelations
                {
                    BlogId = blog.Id, // Yeni oluşturulan blogun Id'sini kullanabilirsiniz
                    CityId = viewModel.SelectedCityId
                };

                db.BlogCityRelations.Add(blogCityRelation);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // ModelState geçerli değilse, dropdown listeleri tekrar doldur
            viewModel.Users = new SelectList(db.User, "Id", "Name");
            viewModel.Cities = new SelectList(db.City, "Id", "Name");

            return View(viewModel);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Surname", blog.UserId);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.User, "Id", "Surname", blog.UserId);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blog.Find(id);
            db.Blog.Remove(blog);
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
