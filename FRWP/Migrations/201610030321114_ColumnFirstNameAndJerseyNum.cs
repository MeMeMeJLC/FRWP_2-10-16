namespace FRWP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnFirstNameAndJerseyNum : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Player", name: "JerseyNumber", newName: "Jersey Number");
            RenameColumn(table: "dbo.Player", name: "FirstMidName", newName: "FirstName");
            RenameColumn(table: "dbo.Player", name: "DateCreated", newName: "Date Created");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Player", name: "Date Created", newName: "DateCreated");
            RenameColumn(table: "dbo.Player", name: "FirstName", newName: "FirstMidName");
            RenameColumn(table: "dbo.Player", name: "Jersey Number", newName: "JerseyNumber");
        }
    }
}
