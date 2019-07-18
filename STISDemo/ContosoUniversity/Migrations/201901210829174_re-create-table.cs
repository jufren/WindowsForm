namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreatetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayList",
                c => new
                {
                    PlayListID = c.String(nullable: false, maxLength: 128),
                    TemplateID = c.String(),
                    Duration = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PlayListID);
            CreateTable(
               "dbo.TimeSlotPlayList",
               c => new
               {
                   TimeSlotPlayListID = c.Int(nullable: false, identity: true),
                   TimeSlotDetailID = c.Int(nullable: false),
                   PlayList_PlayListID = c.String(maxLength: 128),
                   ScheduleDetail_ScheduleDetailID = c.Int(),
               })
               .PrimaryKey(t => t.TimeSlotPlayListID)
               .ForeignKey("dbo.PlayList", t => t.PlayList_PlayListID)
               .ForeignKey("dbo.ScheduleDetail", t => t.ScheduleDetail_ScheduleDetailID)
               .Index(t => t.PlayList_PlayListID)
               .Index(t => t.ScheduleDetail_ScheduleDetailID);
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSlotPlayList", "PlayList_PlayListID", "dbo.PlayList");
            DropIndex("dbo.TimeSlotPlayList", new[] { "PlayList_PlayListID" });
            DropColumn("dbo.TimeSlotPlayList", "PlayList_PlayListID");
        }
    }
}
