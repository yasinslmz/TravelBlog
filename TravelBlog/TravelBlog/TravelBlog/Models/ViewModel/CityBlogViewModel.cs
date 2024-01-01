using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Models.ViewModel
{
    public class CityBlogViewModel
    {
        public List<City> Cities { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}