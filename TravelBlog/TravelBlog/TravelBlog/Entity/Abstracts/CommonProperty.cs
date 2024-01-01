using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelBlog.Entity.Abstracts
{
    public class CommonProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}