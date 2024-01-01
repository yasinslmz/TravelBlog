using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelBlog.Models.ViewModel
{
    public class BlogCreateViewModel
    {
        [AllowHtml]
        public Blog Blog { get; set; }
        public SelectList Users { get; set; }
        public SelectList Cities { get; set; }
        public int SelectedCityId { get; set; } 
    }
}