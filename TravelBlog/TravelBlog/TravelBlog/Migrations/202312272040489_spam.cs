namespace TravelBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "IsSpam", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "IsSpam");
        }
    }
}
