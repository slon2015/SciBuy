namespace SciBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Terms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Terms",
                c => new
                    {
                        TermId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Parent_TermId = c.Int(),
                    })
                .PrimaryKey(t => t.TermId)
                .ForeignKey("dbo.Terms", t => t.Parent_TermId)
                .Index(t => t.Parent_TermId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Terms", "Parent_TermId", "dbo.Terms");
            DropIndex("dbo.Terms", new[] { "Parent_TermId" });
            DropTable("dbo.Terms");
        }
    }
}
