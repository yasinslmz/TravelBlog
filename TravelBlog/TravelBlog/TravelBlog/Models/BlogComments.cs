using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class BlogComments : CommonProperty
    {
        public string comment { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime commentDate { get; set; }
        public bool IsApproved { get; set; }
    }
}