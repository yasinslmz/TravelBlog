using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelBlog.Entity.Interfaces;
using TravelBlog.Models;
namespace TravelBlog.Entity
{
    public class RoleProcess : ICrud<Role>
    {
        DataContext db = new DataContext();
        public string Add(Role entity)
        {
            string result = "";
            try
            {
                var role = db.Role.FirstOrDefault(x => x.Name == entity.Name);

                if (role == null)
                {
                    db.Role.Add(entity);
                    db.SaveChanges();
                    result = entity.Name + " Rolü Eklendi";
                }
                else
                {
                    result = entity.Name + " Rolü Mevcut Başka Bir Rol Deneyiniz.";
                }
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }

            return result;
        }

        public bool Delete(int id)
        {
            var role = db.Role.Find(id);
            if (role != null)
            {
                role.IsDelete = true;
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public Role Get(int id)
        {
            var role = db.Role.FirstOrDefault(x => x.Id == id && !x.IsDelete);

            return role;
        }

        public List<Role> GetAll()
        {
            return db.Role.Where(x => !x.IsDelete).ToList();
        }

        public bool Update(Role entity, int id)
        {
            var role = db.Role.FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if (role != null)
            {
                role.Name = entity.Name;
                role.IsStatus = entity.IsStatus;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}