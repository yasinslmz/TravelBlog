namespace TravelBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        content = c.String(),
                        likeNumbers = c.Int(nullable: false),
                        postDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                        BlogId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        commentDate = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        email = c.String(),
                        RoleId = c.Int(nullable: false),
                        createTime = c.DateTime(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.BlogLikeRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                        Blog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Blogs", t => t.Blog_Id)
                .Index(t => t.UserId)
                .Index(t => t.BlogId)
                .Index(t => t.User_Id)
                .Index(t => t.Blog_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCityRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.CityId)
                .Index(t => t.City_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        IsStatus = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogCityRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BlogCityRelations", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.BlogLikeRelations", "Blog_Id", "dbo.Blogs");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogLikeRelations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BlogLikeRelations", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogLikeRelations", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropIndex("dbo.BlogCityRelations", new[] { "City_Id" });
            DropIndex("dbo.BlogCityRelations", new[] { "CityId" });
            DropIndex("dbo.BlogCityRelations", new[] { "BlogId" });
            DropIndex("dbo.BlogLikeRelations", new[] { "Blog_Id" });
            DropIndex("dbo.BlogLikeRelations", new[] { "User_Id" });
            DropIndex("dbo.BlogLikeRelations", new[] { "BlogId" });
            DropIndex("dbo.BlogLikeRelations", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.Cities");
            DropTable("dbo.BlogCityRelations");
            DropTable("dbo.Roles");
            DropTable("dbo.BlogLikeRelations");
            DropTable("dbo.Users");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Blogs");
        }
    }
}
