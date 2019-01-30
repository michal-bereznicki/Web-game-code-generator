namespace DragonDustWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFieldAddedToGameCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameCodes", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameCodes", "Code");
        }
    }
}
