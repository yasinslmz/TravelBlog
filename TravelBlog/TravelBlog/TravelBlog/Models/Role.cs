using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class Role : CommonProperty
    {
        public List<User> Users { get; set; }
    }
}