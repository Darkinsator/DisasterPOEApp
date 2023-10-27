namespace DisasterPOEApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisasterPOEApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorizedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        AidType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodsDonations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category = c.String(),
                        description = c.String(nullable: false),
                        items = c.Int(nullable: false),
                        date = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MoneyDonations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Int(nullable: false),
                        description = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.MoneyDonations");
            DropTable("dbo.GoodsDonations");
            DropTable("dbo.Disasters");
            DropTable("dbo.AuthorizedUsers");
        }
    }
}
