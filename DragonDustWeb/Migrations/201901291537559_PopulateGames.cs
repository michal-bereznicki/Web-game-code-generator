namespace DragonDustWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games (Name, GooglePlayPageLink) VALUES('Ancient Tomb Adventure','https://play.google.com/store/apps/details?id=com.DragonDustGames.labyrinth.adventure.puzzle.riddle.ancient.tomb')");
            Sql("INSERT INTO Games (Name, GooglePlayPageLink) VALUES('Kids Music Composer','https://play.google.com/store/apps/details?id=com.dragondustgames.kids.music.learn.composer.KidsMusicComposerFunLearn')");
        }
        
        public override void Down()
        {
        }
    }
}
