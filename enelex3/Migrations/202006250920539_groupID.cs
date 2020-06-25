namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaveMeasures", "GroupID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaveMeasures", "GroupID");
        }
    }
}
