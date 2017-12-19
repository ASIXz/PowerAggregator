namespace DesctopPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MessageDatas");
            AddColumn("dbo.MessageDatas", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MessageDatas", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MessageDatas");
            DropColumn("dbo.MessageDatas", "Id");
            AddPrimaryKey("dbo.MessageDatas", "Date");
        }
    }
}
