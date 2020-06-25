
    namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_measure : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Measures", "IndexId");
            DropColumn("dbo.Measures", "P");
            DropColumn("dbo.Measures", "GeAsh");
            DropColumn("dbo.Measures", "LabAsh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Measures", "LabAsh", c => c.Double(nullable: false));
            AddColumn("dbo.Measures", "GeAsh", c => c.Double(nullable: false));
            AddColumn("dbo.Measures", "P", c => c.Double(nullable: false));
            AddColumn("dbo.Measures", "IndexId", c => c.Double(nullable: false));
        }
    }
}
