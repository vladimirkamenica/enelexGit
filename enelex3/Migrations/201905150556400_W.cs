namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class W : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "W", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "W");
        }
    }
}
