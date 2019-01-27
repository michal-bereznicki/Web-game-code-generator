namespace DragonDustWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrderTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO OrderTypes (Name) VALUES ('FreePromoCodeByEmail')");
        }
        
        public override void Down()
        {
        }
    }
}
