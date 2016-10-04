namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Game", "GameTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Game", "GameDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "GameDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Game", "GameTime");
            DropColumn("dbo.Game", "GameDate");
        }
    }
}
