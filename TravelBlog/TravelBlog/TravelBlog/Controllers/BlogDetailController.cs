using System;
using System.Collections.Generic;
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
    public class BlogDetailController : Controller
    {
        DataContext db = new DataContext();
        // GET: BlogDetail
        public ActionResult Index(int id = 0)
        {
            Blog blog = db.Blog.Find(id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            // Blog ve Comment modellerini içeren ViewModel'i oluştur
            var viewModel = new BlogDetailViewModel
            {
                Blog = blog,
                Comment = new BlogComments() // İlgili comment için bir örnek oluşturabilirsiniz
            };
            // Kullanıcı adlarını içeren bir liste oluştur
            var userIds = db.BlogComments.Where(c => c.BlogId == id).Select(c => c.UserId).Distinct().ToList();
            var userNames = db.User.Where(u => userIds.Contains(u.Id)).ToDictionary(u => u.Id, u => u.userName);

            // ViewBag'e kullanıcı adlarını ve yorumları ekleyin
            ViewBag.UserNames = userNames;
            ViewBag.CommentsList = db.BlogComments.Where(c => c.BlogId == id && c.IsApproved).ToList();
            ViewData["Users"] = db.User.ToList();


            var loggedInUser = Session["LoggedInUser"] as User;

            ViewBag.LoggedInUser = loggedInUser;

            return View(viewModel);


        }
        [HttpPost]
        public ActionResult AddComment(int id, BlogComments comment)
        {
            BlogComments blogComments = comment;
            if (ModelState.IsValid)
            {
                var loggedInUser = Session["LoggedInUser"] as User;

                if (loggedInUser == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                comment.BlogId = id;
                comment.UserId = loggedInUser.Id;
                comment.commentDate = DateTime.Now;
                comment.IsApproved = false;

                db.BlogComments.Add(comment);
                db.SaveChanges();

                return RedirectToAction("Index", "BlogDetail", new { id = id });
            }

            // Eğer ModelState geçerli değilse, tekrar ViewModel ile dön
            var blog = db.Blog.Find(id);
            var viewModel = new BlogDetailViewModel
            {
                Blog = blog,
                Comment = comment
            };

            return View("Index", viewModel);


        }

        public ActionResult IncreaseLike(int id)
        {
            var blog = db.Blog.Find(id);

            if (blog == null)
            {
                return HttpNotFound();
            }
            var loggedInUser = Session["LoggedInUser"] as User;

            if(loggedInUser != null)
            {
                // Daha önce bu blogu beğenip beğenmediğini kontrol et
                var existingLike = db.BlogLikeRelations.FirstOrDefault(l => l.UserId == loggedInUser.Id && l.BlogId == id);
                if (existingLike == null)
                {
                    // Daha önce beğenilmemişse beğeni ekleyin
                    var like = new BlogLikeRelation { UserId = loggedInUser.Id, BlogId = id };
                    db.BlogLikeRelations.Add(like);
                    db.SaveChanges();

                    // Blog'un beğeni sayısını artırın
                    var bl = db.Blog.Find(id);
                    if (bl != null)
                    {
                        blog.likeNumbers++;
                        db.SaveChanges();
                    }
                }
            }
        
            return RedirectToAction("Index", "Login");
      
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
                var loggedInUser = Session["LoggedInUser"] as User;
                blog.UserId = loggedInUser.Id;
                blog.IsStatus= true;
                blog.IsDelete= false;
                blog.postDate= DateTime.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            var x = blog;
            ViewBag.UserId = new SelectList(db.User, "Id", "Surname", blog.UserId);
            return View(blog);
        }


        public ActionResult Spam(int id)
        {
            // Belirli bir blogu bul
            var blog = db.Blog.Find(id);

            if (blog != null)
            {
                // Blog varsa IsSpam değerini true yap
                blog.IsSpam = true;

                // Değişikliği kaydet
                db.SaveChanges();

                // İlgili blogun Spam view'ini göster
                return RedirectToAction("Index","Home");
            }
            else
            {
                // Blog bulunamazsa, bir hata mesajı döndür
                ViewBag.ErrorMessage = "Blog not found!";
                return RedirectToAction("Index", "Home");
            }
        }


    }
}