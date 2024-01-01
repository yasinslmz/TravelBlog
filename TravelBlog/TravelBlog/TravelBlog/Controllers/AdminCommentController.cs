using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity;

namespace TravelBlog.Controllers
{
    public class AdminCommentController : Controller
    {
        DataContext db=new DataContext();
        // GET: AdminComment
        public ActionResult Index()
        {
            var comments = db.BlogComments.Include("User").ToList();
            return View(comments);

        }
        [HttpPost]
        public ActionResult ApproveComment(int id, bool isApproved)
        {
            var comment = db.BlogComments.Find(id);
            if (comment != null)
            {
                comment.IsApproved = isApproved;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}