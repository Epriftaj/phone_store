namespace PROJECT_FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorytbls",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorytbls", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Categorytbls", new[] { "User_Id" });
            DropTable("dbo.Categorytbls");
        }
    }
}
