namespace PROJECT_FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productrel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ImgUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categorytbls", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categorytbls");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropTable("dbo.Products");
        }
    }
}
