namespace CalgaryHacks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherIndicatorsofLifeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OtherIndicatorsOfLives",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                        PercentageOfDrivingAloneToWork = c.String(),
                        PercentageOfActiveAdults = c.String(),
                        PercentageToDailyNeedsAndServices = c.String(),
                        CommunityBelonging = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OtherIndicatorsOfLives");
        }
    }
}
