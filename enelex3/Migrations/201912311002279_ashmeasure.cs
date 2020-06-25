namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ashmeasure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "GeAsh", c => c.Double(nullable: false));
            AddColumn("dbo.Measures", "LabAsh", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "LabAsh");
            DropColumn("dbo.Measures", "GeAsh");
        }
    }
}
