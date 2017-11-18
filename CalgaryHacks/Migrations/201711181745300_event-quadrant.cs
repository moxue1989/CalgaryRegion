namespace CalgaryHacks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventquadrant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Quadrant", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Quadrant");
        }
    }
}
