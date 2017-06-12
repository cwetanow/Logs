namespace Logs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscriptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TrainingLogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId)
                .ForeignKey("dbo.TrainingLogs", t => t.TrainingLogId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TrainingLogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscriptions", "TrainingLogId", "dbo.TrainingLogs");
            DropIndex("dbo.Subscriptions", new[] { "TrainingLogId" });
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            DropTable("dbo.Subscriptions");
        }
    }
}
