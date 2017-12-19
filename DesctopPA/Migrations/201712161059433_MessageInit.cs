namespace DesctopPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageDatas",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(),
                        Text = c.String(),
                        Recived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Date);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessageDatas");
        }
    }
}
