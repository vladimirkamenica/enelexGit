namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRegistrationAdministrator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegistrationUsers", "Administrator", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegistrationUsers", "Administrator");
        }
    }
}
