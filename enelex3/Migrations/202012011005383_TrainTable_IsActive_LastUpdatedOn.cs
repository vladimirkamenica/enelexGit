namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainTable_IsActive_LastUpdatedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainTables", "LastUpdatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.TrainTables", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainTables", "IsActive");
            DropColumn("dbo.TrainTables", "LastUpdatedOn");
        }
    }
}
