namespace Logs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Name" });
            CreateTable(
                "dbo.Measurements",
                c => new
                {
                    MeasurementId = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    UserId = c.String(nullable: false, maxLength: 128),
                    Heigh = c.Int(nullable: false),
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
                })
                .PrimaryKey(t => t.MeasurementId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Nutritions",
                c => new
                {
                    NutritionId = c.Int(nullable: false, identity: true),
                    Notes = c.String(),
                    Date = c.DateTime(nullable: false),
                    UserId = c.String(nullable: false, maxLength: 128),
                    Calories = c.Int(nullable: false),
                    GoalCalories = c.Int(nullable: false),
                    Protein = c.Int(nullable: false),
                    GoalProtein = c.Int(nullable: false),
                    Carbs = c.Int(nullable: false),
                    GoalCarbs = c.Int(nullable: false),
                    Fats = c.Int(nullable: false),
                    GoalFats = c.Int(nullable: false),
                    WaterInLitres = c.Double(nullable: false),
                    GoalWaterInLitres = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.NutritionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.DailyNutritionGoals",
                c => new
                {
                    DailyNutritionGoalsId = c.Int(nullable: false, identity: true),
                    Calories = c.Int(nullable: false),
                    Protein = c.Int(nullable: false),
                    Carbs = c.Int(nullable: false),
                    Fats = c.Int(nullable: false),
                    WaterInLitres = c.Double(nullable: false),
                    UserId = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.DailyNutritionGoalsId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            AddColumn("dbo.AspNetUsers", "RestDayNutritionGoals_DailyNutritionGoalsId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "TrainingDayNutritionGoals_DailyNutritionGoalsId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "RestDayNutritionGoals_DailyNutritionGoalsId");
            CreateIndex("dbo.AspNetUsers", "TrainingDayNutritionGoals_DailyNutritionGoalsId");
            AddForeignKey("dbo.AspNetUsers", "RestDayNutritionGoals_DailyNutritionGoalsId", "dbo.DailyNutritionGoals", "DailyNutritionGoalsId");
            AddForeignKey("dbo.AspNetUsers", "TrainingDayNutritionGoals_DailyNutritionGoalsId", "dbo.DailyNutritionGoals", "DailyNutritionGoalsId");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 20));
            DropForeignKey("dbo.AspNetUsers", "TrainingDayNutritionGoals_DailyNutritionGoalsId", "dbo.DailyNutritionGoals");
            DropForeignKey("dbo.AspNetUsers", "RestDayNutritionGoals_DailyNutritionGoalsId", "dbo.DailyNutritionGoals");
            DropForeignKey("dbo.DailyNutritionGoals", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Nutritions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Measurements", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.DailyNutritionGoals", new[] { "UserId" });
            DropIndex("dbo.Nutritions", new[] { "UserId" });
            DropIndex("dbo.Measurements", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "TrainingDayNutritionGoals_DailyNutritionGoalsId" });
            DropIndex("dbo.AspNetUsers", new[] { "RestDayNutritionGoals_DailyNutritionGoalsId" });
            DropColumn("dbo.AspNetUsers", "TrainingDayNutritionGoals_DailyNutritionGoalsId");
            DropColumn("dbo.AspNetUsers", "RestDayNutritionGoals_DailyNutritionGoalsId");
            DropColumn("dbo.AspNetUsers", "ProfileImageUrl");
            DropColumn("dbo.AspNetUsers", "Description");
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "BodyFatPercent");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Weight");
            DropColumn("dbo.AspNetUsers", "GenderType");
            DropColumn("dbo.TrainingLogs", "Owner");
            DropTable("dbo.DailyNutritionGoals");
            DropTable("dbo.Nutritions");
            DropTable("dbo.Measurements");
            CreateIndex("dbo.AspNetUsers", "Name", unique: true);
        }
    }
}
