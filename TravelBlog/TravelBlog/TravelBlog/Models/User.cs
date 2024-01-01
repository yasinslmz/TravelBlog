using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Abstracts;

namespace TravelBlog.Models
{
    public class User : CommonProperty
    {
        public string Surname { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime createTime { get; set; }
        
        public List<Blog> Blogs { get; set; }
        public List<BlogComments> BlogCommentsList { get; set; }
        public List<BlogLikeRelation> BlogLikeRelations { get; set; }
    }
}