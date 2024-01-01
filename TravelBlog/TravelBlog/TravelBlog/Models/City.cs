using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class City : CommonProperty
    {
        public List<BlogCityRelations> BlogRelations { get; set; }
    }
}