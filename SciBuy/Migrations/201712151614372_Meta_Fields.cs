namespace SciBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Meta_Fields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaFields",
                c => new
                    {
                        MetaFieldId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        AppUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MetaFieldId)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUser_Id)
                .Index(t => t.AppUser_Id);
            
            AddColumn("dbo.AspNetUsers", "RealName", c => c.String());
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaFields", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MetaFields", new[] { "AppUser_Id" });
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
            DropColumn("dbo.AspNetUsers", "RealName");
            DropTable("dbo.MetaFields");
        }
    }
}
