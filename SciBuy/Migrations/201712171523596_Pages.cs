namespace SciBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatingDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pages", new[] { "Author_Id" });
            DropTable("dbo.Pages");
        }
    }
}
