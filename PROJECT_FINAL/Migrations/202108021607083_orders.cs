namespace PROJECT_FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "InvoiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "InvoiceId");
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "InvoiceId" });
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Orders", "InvoiceId");
        }
    }
}
