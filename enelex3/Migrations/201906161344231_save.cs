namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class save : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "Save", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "Save");
        }
    }
}
