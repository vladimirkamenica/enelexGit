namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _idsort_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "IdSort", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "IdSort");
        }
    }
}
