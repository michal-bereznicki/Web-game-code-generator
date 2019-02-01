namespace DragonDustWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameIdAddedToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "GameId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "GameId");
        }
    }
}
