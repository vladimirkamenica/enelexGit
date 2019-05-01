namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _P_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "P", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "P");
        }
    }
}
