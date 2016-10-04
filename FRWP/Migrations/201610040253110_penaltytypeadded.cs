namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class penaltytypeadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PenaltyType",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PenaltyType");
        }
    }
}
