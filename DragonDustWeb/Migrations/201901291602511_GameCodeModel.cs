namespace DragonDustWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameCodeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Used = c.Boolean(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameCodes");
        }
    }
}
