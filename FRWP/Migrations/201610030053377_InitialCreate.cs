namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlayer",
                c => new
                    {
                        GamePlayerID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        IsStartingSubstitute = c.Boolean(nullable: false),
                        IsCaptain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GamePlayerID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        GameDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JerseyNumber = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamePlayer", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.GamePlayer", "GameID", "dbo.Game");
            DropIndex("dbo.GamePlayer", new[] { "GameID" });
            DropIndex("dbo.GamePlayer", new[] { "PlayerID" });
            DropTable("dbo.Player");
            DropTable("dbo.Game");
            DropTable("dbo.GamePlayer");
        }
    }
}
