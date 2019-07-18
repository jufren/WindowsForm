namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertable : DbMigration
    {
        public override void Up()
        {
            /*DropForeignKey("dbo.TimeSlotPlayList", "PlayList_PlayListID", "dbo.PlayList");
            DropIndex("dbo.TimeSlotPlayList", new[] { "PlayList_PlayListID" });
            DropColumn("dbo.TimeSlotPlayList", "PlayList_PlayListID");*/
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeSlotPlayList", "PlayList_PlayListID", c => c.String(maxLength: 128));
            CreateIndex("dbo.TimeSlotPlayList", "PlayList_PlayListID");
            AddForeignKey("dbo.TimeSlotPlayList", "PlayList_PlayListID", "dbo.PlayList", "PlayListID");
        }
    }
}
