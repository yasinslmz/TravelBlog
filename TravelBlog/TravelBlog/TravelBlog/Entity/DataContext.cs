using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelBlog.Models;

namespace TravelBlog.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DbConnection") { }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Blog> Blog { get; set; }
      
        public DbSet<BlogComments> BlogComments { get; set; }
        public DbSet<BlogCityRelations> BlogCityRelations { get; set; }
        public DbSet<BlogLikeRelation> BlogLikeRelations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User - Blog ilişkisi
            modelBuilder.Entity<User>()
                .HasMany(u => u.Blogs)
                .WithRequired(b => b.User)
                .HasForeignKey(b => b.UserId)
                .WillCascadeOnDelete(false); // Cascade Delete'i kapat
            // Blog - BlogComments ilişkisi
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.BlogComments)
                .WithRequired(bc => bc.Blog)
                .HasForeignKey(bc => bc.BlogId)
                .WillCascadeOnDelete(false); // Cascade Delete'i kapat

           
            modelBuilder.Entity<BlogLikeRelation>()
                .HasRequired(blr => blr.User)
                .WithMany()
                .HasForeignKey(blr => blr.UserId)
                .WillCascadeOnDelete(false);


            

            modelBuilder.Entity<BlogLikeRelation>()
                .HasRequired(blr => blr.Blog)
                .WithMany()
                .HasForeignKey(blr => blr.BlogId)
                .WillCascadeOnDelete(false);



            // Blog - BlogCityRelations ilişkisi
            modelBuilder.Entity<Blog>()
                .HasMany(b => b.BlogRelations)
                .WithRequired(br => br.Blog)
                .HasForeignKey(br => br.BlogId)
                .WillCascadeOnDelete(false); // Cascade Delete'i kapat

            // BlogCityRelations - City ilişkisi
            modelBuilder.Entity<BlogCityRelations>()
                .HasRequired(br => br.City)
                .WithMany()
                .HasForeignKey(br => br.CityId)
                .WillCascadeOnDelete(false); // Cascade Delete'i kapat

            // Diğer ilişkileri buraya ekleyebilirsiniz.

            base.OnModelCreating(modelBuilder);
        }
    }
}