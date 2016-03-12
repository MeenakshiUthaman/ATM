namespace AtmUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        SSN = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterViewModels");
        }
    }
}
