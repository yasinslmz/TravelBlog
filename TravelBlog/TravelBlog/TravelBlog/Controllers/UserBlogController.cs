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
    public class UserBlogController : Controller
    {
        private DataContext db = new DataContext();

        // GET: UserBlog
        public ActionResult Index()
        {
            var loggedInUser = Session["LoggedInUser"] as User;
            ViewBag.LoggedInUser = loggedInUser;

            var blog = db.Blog.Include(b => b.User).Where(b=>b.UserId==loggedInUser.Id);
        
            if (loggedInUser == null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                return View(blog.ToList());
            }

        }

        // GET: UserBlog/Details/5
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

        // GET: UserBlog/Create
        public ActionResult Create()
        {
            var viewModel = new BlogCreateViewModel
            {
                Blog = new Blog(),
                Users = new SelectList(db.User, "Id", "Name"),
                Cities = new SelectList(db.City, "Id", "Name")
            };
            // Giriş yapmış kullanıcının bilgilerini al
            var loggedInUser = Session["LoggedInUser"] as User;
            ViewBag.LoggedInUser = loggedInUser;
            return View(viewModel);
        }

        // POST: UserBlog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Giriş yapmış kullanıcının bilgilerini al
                var loggedInUser = Session["LoggedInUser"] as User;

               
                // Eğer giriş yapmış bir kullanıcı varsa, UserId'yi bu kullanıcının Id'si olarak ayarla
                if (loggedInUser != null)
                {
                    viewModel.Blog.UserId = loggedInUser.Id;
                }
                else
                {
                    // Kullanıcı giriş yapmamışsa veya bilgileri alınamamışsa bir hata mesajı göster
                    ModelState.AddModelError("", "Kullanıcı bilgileri alınamadı.");
                    ViewBag.UserId = new SelectList(db.User, "Id", "Surname", viewModel.Blog.UserId);
                    return View(viewModel.Blog);
                }
                var bl=viewModel.Blog;
                viewModel.Blog.UserId=loggedInUser.Id;
                viewModel.Blog.postDate = DateTime.Now;
                viewModel.Blog.IsDelete = false;
                viewModel.Blog.IsStatus = true;
                var ornek=viewModel.Blog;

                db.Blog.Add(viewModel.Blog);
                db.SaveChanges();

                // Blog ve City arasındaki ilişkiyi oluşturmak için yeni bir BlogCityRelations girişi ekleyin
                var blogCityRelation = new BlogCityRelations
                {
                    BlogId = viewModel.Blog.Id, // Yeni oluşturulan blogun Id'sini kullanabilirsiniz
                    CityId = viewModel.SelectedCityId
                };

                db.BlogCityRelations.Add(blogCityRelation);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.User, "Id", "Surname", viewModel.Blog.UserId);
            return View(viewModel.Blog);
        }

        // GET: UserBlog/Edit/5
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

        // POST: UserBlog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,content,likeNumbers,postDate,UserId,Name,Description,Image,IsStatus,IsDelete")] Blog blog)
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

        // GET: UserBlog/Delete/5
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

        // POST: UserBlog/Delete/5
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
