namespace TravelBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadeUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogCityRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogLikeRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogLikeRelations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities");
            AddForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs", "Id");
            AddForeignKey("dbo.BlogCityRelations", "BlogId", "dbo.Blogs", "Id");
            AddForeignKey("dbo.BlogLikeRelations", "BlogId", "dbo.Blogs", "Id");
            AddForeignKey("dbo.BlogLikeRelations", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BlogLikeRelations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogLikeRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogCityRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            AddForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogLikeRelations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogLikeRelations", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogCityRelations", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
        }
    }
}
