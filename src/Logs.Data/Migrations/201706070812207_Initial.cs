namespace Logs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        EntryId = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.LogEntries", t => t.EntryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.EntryId);
            
            CreateTable(
                "dbo.LogEntries",
                c => new
                    {
                        LogEntryId = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        LogId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LogEntryId)
                .ForeignKey("dbo.TrainingLogs", t => t.LogId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LogId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TrainingLogs",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        LastActivityUser = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastEntryDate = c.DateTime(nullable: false),
                        LastEntryId = c.Int(),
                        UserId = c.String(maxLength: 128),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.LogEntries", t => t.LastEntryId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LastEntryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LogId = c.Int(),
                        GenderType = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Age = c.Int(nullable: false),
                        BodyFatPercent = c.Double(nullable: false),
                        Height = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        ProfileImageUrl = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingLogs", t => t.LogId)
                .Index(t => t.LogId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementsId = c.Int(nullable: false, identity: true),
                        Height = c.Int(nullable: false),
                        WeightKg = c.Double(nullable: false),
                        BodyFatPercent = c.Double(nullable: false),
                        Chest = c.Int(nullable: false),
                        Shoulders = c.Int(nullable: false),
                        Forearm = c.Int(nullable: false),
                        Arm = c.Int(nullable: false),
                        Waist = c.Int(nullable: false),
                        Hips = c.Int(nullable: false),
                        Thighs = c.Int(nullable: false),
                        Calves = c.Int(nullable: false),
                        Neck = c.Int(nullable: false),
                        Wrist = c.Int(nullable: false),
                        Ankle = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MeasurementsId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Nutritions",
                c => new
                    {
                        NutritionId = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        Calories = c.Int(nullable: false),
                        Protein = c.Int(nullable: false),
                        Carbs = c.Int(nullable: false),
                        Fats = c.Int(nullable: false),
                        WaterInLitres = c.Double(nullable: false),
                        Fiber = c.Int(nullable: false),
                        Sugar = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NutritionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        LogVoteId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        LogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogVoteId)
                .ForeignKey("dbo.TrainingLogs", t => t.LogId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.LogId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "EntryId", "dbo.LogEntries");
            DropForeignKey("dbo.LogEntries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LogEntries", "LogId", "dbo.TrainingLogs");
            DropForeignKey("dbo.TrainingLogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "LogId", "dbo.TrainingLogs");
            DropForeignKey("dbo.AspNetUsers", "LogId", "dbo.TrainingLogs");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Nutritions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Measurements", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainingLogs", "LastEntryId", "dbo.LogEntries");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Votes", new[] { "LogId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Nutritions", new[] { "UserId" });
            DropIndex("dbo.Measurements", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "LogId" });
            DropIndex("dbo.TrainingLogs", new[] { "UserId" });
            DropIndex("dbo.TrainingLogs", new[] { "LastEntryId" });
            DropIndex("dbo.LogEntries", new[] { "UserId" });
            DropIndex("dbo.LogEntries", new[] { "LogId" });
            DropIndex("dbo.Comments", new[] { "EntryId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Votes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Nutritions");
            DropTable("dbo.Measurements");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TrainingLogs");
            DropTable("dbo.LogEntries");
            DropTable("dbo.Comments");
        }
    }
}
