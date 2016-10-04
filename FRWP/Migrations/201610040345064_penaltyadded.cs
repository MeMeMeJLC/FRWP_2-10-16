namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class penaltyadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePenalty",
                c => new
                    {
                        PenaltyID = c.Int(nullable: false, identity: true),
                        PenaltyCode = c.String(maxLength: 128),
                        GamePlayerID = c.Int(nullable: false),
                        TimePenaltyOccurred = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PenaltyID)
                .ForeignKey("dbo.GamePlayer", t => t.GamePlayerID, cascadeDelete: true)
                .ForeignKey("dbo.PenaltyType", t => t.PenaltyCode)
                .Index(t => t.PenaltyCode)
                .Index(t => t.GamePlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePenalty", "PenaltyCode", "dbo.PenaltyType");
            DropForeignKey("dbo.GamePenalty", "GamePlayerID", "dbo.GamePlayer");
            DropIndex("dbo.GamePenalty", new[] { "GamePlayerID" });
            DropIndex("dbo.GamePenalty", new[] { "PenaltyCode" });
            DropTable("dbo.GamePenalty");
        }
    }
}
