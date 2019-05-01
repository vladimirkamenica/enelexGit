namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sort : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Measures", "IdSort");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Measures", "IdSort", c => c.Int(nullable: false));
        }
    }
}
