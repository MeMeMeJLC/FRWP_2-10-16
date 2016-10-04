namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goalmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Player", name: "Date Created", newName: "DateCreated");
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsOwnGoal = c.Boolean(nullable: false),
                        GamePlayerID = c.Int(nullable: false),
                        TimeScored = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GamePlayer", t => t.GamePlayerID, cascadeDelete: true)
                .Index(t => t.GamePlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goal", "GamePlayerID", "dbo.GamePlayer");
            DropIndex("dbo.Goal", new[] { "GamePlayerID" });
            DropTable("dbo.Goal");
            RenameColumn(table: "dbo.Player", name: "DateCreated", newName: "Date Created");
        }
    }
}
