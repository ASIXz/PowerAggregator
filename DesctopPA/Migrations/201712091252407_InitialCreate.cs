namespace DesctopPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SerializedAccounts",
                c => new
                    {
                        AccountId = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
            CreateTable(
                "dbo.AgregatorUserDatas",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.ChatterUserDatas",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ChatterId = c.String(),
                        UserId = c.String(),
                        UserAdditionalSpec = c.String(),
                        AgregatorUserId = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChatterUserDatas");
            DropTable("dbo.AgregatorUserDatas");
            DropTable("dbo.SerializedAccounts");
        }
    }
}
