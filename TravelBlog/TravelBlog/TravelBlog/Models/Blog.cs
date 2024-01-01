using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class Blog : CommonProperty
    {
        public string title { get; set; }
        public bool IsSpam { get; set; }

        [AllowHtml]
        public string content { get; set; }
        public int likeNumbers { get; set; }
        public DateTime postDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BlogComments> BlogComments { get; set; }
        public List<BlogCityRelations> BlogRelations { get; set; }
        public List<BlogLikeRelation> BlogLikeRelations { get; set; }
    }
}