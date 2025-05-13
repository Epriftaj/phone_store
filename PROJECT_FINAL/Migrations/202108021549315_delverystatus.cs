namespace PROJECT_FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delverystatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DeliveryStatusId = c.Int(nullable: false),
                        UserId = c.String(nullable: false),
                        InsertedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryStatus", t => t.DeliveryStatusId, cascadeDelete: true)
                .Index(t => t.DeliveryStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "DeliveryStatusId", "dbo.DeliveryStatus");
            DropIndex("dbo.Invoices", new[] { "DeliveryStatusId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.DeliveryStatus");
        }
    }
}
