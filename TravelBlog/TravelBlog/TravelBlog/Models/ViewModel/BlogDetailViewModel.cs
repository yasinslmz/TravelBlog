using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.ViewModel
{
    public class BlogDetailViewModel
    {
        public Blog Blog { get; set; }
        public BlogComments Comment { get; set; }
    }
}