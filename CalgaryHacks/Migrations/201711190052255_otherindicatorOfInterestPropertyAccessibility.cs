namespace CalgaryHacks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otherindicatorOfInterestPropertyAccessibility : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OtherIndicatorsOfLives", "PercentageCommunityBelonging", c => c.String());
            AddColumn("dbo.OtherIndicatorsOfLives", "PercentageAccessibilityTransit", c => c.String());
            DropColumn("dbo.OtherIndicatorsOfLives", "CommunityBelonging");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OtherIndicatorsOfLives", "CommunityBelonging", c => c.String());
            DropColumn("dbo.OtherIndicatorsOfLives", "PercentageAccessibilityTransit");
            DropColumn("dbo.OtherIndicatorsOfLives", "PercentageCommunityBelonging");
        }
    }
}
