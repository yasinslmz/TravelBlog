using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class BlogCityRelations : CommonProperty
    {
        
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}