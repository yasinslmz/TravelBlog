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
    public class CityController : Controller
    {
        public DataContext db = new DataContext();

        public ActionResult Index(int id)
        {
            try
            {
                var loggedInUser = Session["LoggedInUser"] as User;
                ViewBag.LoggedInUser = loggedInUser;

                var cities = db.City.ToList();
                var selectedCity = db.City.FirstOrDefault(c => c.Id == id);
                // Eğer seçilen şehir varsa, ona ait blogları çek
                
                ViewBag.SelectedCity = selectedCity;
                var bloglist = from bc in db.BlogCityRelations
                               join bs in db.Blog on bc.BlogId equals bs.Id
                               where bc.CityId == selectedCity.Id
                               select bs;

                var bloglist2 =bloglist.ToList();
                var viewModel = new CityBlogViewModel
                {
                    Cities = cities,
                    Blogs = bloglist.ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
                return View(); // Hata durumunda boş bir ViewModel dönebilirsiniz veya hata sayfasına yönlendirebilirsiniz.
            }
        }



        // GET: City/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.City.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Image,IsStatus,IsDelete")] City city)
        {
            if (ModelState.IsValid)
            {
                db.City.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: City/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.City.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: City/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Image,IsStatus,IsDelete")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.City.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.City.Find(id);
            db.City.Remove(city);
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
