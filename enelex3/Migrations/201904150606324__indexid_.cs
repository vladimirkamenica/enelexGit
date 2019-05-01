namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _indexid_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Measures", "IndexId", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Measures", "IndexId");
        }
    }
}
