namespace enelex3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistrationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        UserEmail = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SexEnum = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LastOnUpdate = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegistrationUsers");
        }
    }
}
