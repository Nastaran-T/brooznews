namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentNews",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Website = c.String(),
                        CommentText = c.String(nullable: false, maxLength: 500),
                        CreateComment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.News", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Title = c.String(maxLength: 250),
                        ShortDescription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(nullable: false),
                        ImageName = c.String(),
                        CreatePage = c.DateTime(nullable: false),
                        Tags = c.String(),
                        Visit = c.Int(nullable: false),
                        ShowSlider = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.NewsGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.NewsGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "GroupId", "dbo.NewsGroups");
            DropForeignKey("dbo.CommentNews", "PageId", "dbo.News");
            DropIndex("dbo.News", new[] { "GroupId" });
            DropIndex("dbo.CommentNews", new[] { "PageId" });
            DropTable("dbo.NewsGroups");
            DropTable("dbo.News");
            DropTable("dbo.CommentNews");
            DropTable("dbo.AdminLogins");
        }
    }
}
