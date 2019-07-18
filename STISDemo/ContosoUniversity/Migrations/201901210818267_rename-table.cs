namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renametable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MonthPlan", newName: "MonthPlan1");
            RenameTable(name: "dbo.MonthPlanDetail", newName: "MonthPlanDetail1");
            RenameTable(name: "dbo.Schedule", newName: "Schedule1");
            RenameTable(name: "dbo.ScheduleDetail", newName: "ScheduleDetail1");
            RenameTable(name: "dbo.TimeSlotPlayList", newName: "TimeSlotPlayList1");
            RenameTable(name: "dbo.PlayList", newName: "PlayList1");
            RenameTable(name: "dbo.PlayListDetail", newName: "PlayListDetail1");
            RenameTable(name: "dbo.TimeSlot", newName: "TimeSlot1");
            RenameTable(name: "dbo.TimeSlotDetail", newName: "TimeSlotDetail1");
            RenameColumn(table: "dbo.MonthPlanDetail1", name: "MonthPlan_MonthPlanID", newName: "MonthPlan1_MonthPlanID");
            RenameColumn(table: "dbo.ScheduleDetail1", name: "Schedule_ScheduleID", newName: "Schedule1_ScheduleID");
            RenameColumn(table: "dbo.TimeSlotPlayList1", name: "ScheduleDetail_ScheduleDetailID", newName: "ScheduleDetail1_ScheduleDetailID");
            RenameColumn(table: "dbo.PlayListDetail1", name: "PlayList_PlayListID", newName: "PlayList1_PlayListID");
            RenameColumn(table: "dbo.TimeSlotDetail1", name: "TimeSlot_TimeSlotID", newName: "TimeSlot1_TimeSlotID");
            RenameIndex(table: "dbo.MonthPlanDetail1", name: "IX_MonthPlan_MonthPlanID", newName: "IX_MonthPlan1_MonthPlanID");
            RenameIndex(table: "dbo.ScheduleDetail1", name: "IX_Schedule_ScheduleID", newName: "IX_Schedule1_ScheduleID");
            RenameIndex(table: "dbo.TimeSlotPlayList1", name: "IX_ScheduleDetail_ScheduleDetailID", newName: "IX_ScheduleDetail1_ScheduleDetailID");
            RenameIndex(table: "dbo.PlayListDetail1", name: "IX_PlayList_PlayListID", newName: "IX_PlayList1_PlayListID");
            RenameIndex(table: "dbo.TimeSlotDetail1", name: "IX_TimeSlot_TimeSlotID", newName: "IX_TimeSlot1_TimeSlotID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TimeSlotDetail1", name: "IX_TimeSlot1_TimeSlotID", newName: "IX_TimeSlot_TimeSlotID");
            RenameIndex(table: "dbo.PlayListDetail1", name: "IX_PlayList1_PlayListID", newName: "IX_PlayList_PlayListID");
            RenameIndex(table: "dbo.TimeSlotPlayList1", name: "IX_ScheduleDetail1_ScheduleDetailID", newName: "IX_ScheduleDetail_ScheduleDetailID");
            RenameIndex(table: "dbo.ScheduleDetail1", name: "IX_Schedule1_ScheduleID", newName: "IX_Schedule_ScheduleID");
            RenameIndex(table: "dbo.MonthPlanDetail1", name: "IX_MonthPlan1_MonthPlanID", newName: "IX_MonthPlan_MonthPlanID");
            RenameColumn(table: "dbo.TimeSlotDetail1", name: "TimeSlot1_TimeSlotID", newName: "TimeSlot_TimeSlotID");
            RenameColumn(table: "dbo.PlayListDetail1", name: "PlayList1_PlayListID", newName: "PlayList_PlayListID");
            RenameColumn(table: "dbo.TimeSlotPlayList1", name: "ScheduleDetail1_ScheduleDetailID", newName: "ScheduleDetail_ScheduleDetailID");
            RenameColumn(table: "dbo.ScheduleDetail1", name: "Schedule1_ScheduleID", newName: "Schedule_ScheduleID");
            RenameColumn(table: "dbo.MonthPlanDetail1", name: "MonthPlan1_MonthPlanID", newName: "MonthPlan_MonthPlanID");
            RenameTable(name: "dbo.TimeSlotDetail1", newName: "TimeSlotDetail");
            RenameTable(name: "dbo.TimeSlot1", newName: "TimeSlot");
            RenameTable(name: "dbo.PlayListDetail1", newName: "PlayListDetail");
            RenameTable(name: "dbo.PlayList1", newName: "PlayList");
            RenameTable(name: "dbo.TimeSlotPlayList1", newName: "TimeSlotPlayList");
            RenameTable(name: "dbo.ScheduleDetail1", newName: "ScheduleDetail");
            RenameTable(name: "dbo.Schedule1", newName: "Schedule");
            RenameTable(name: "dbo.MonthPlanDetail1", newName: "MonthPlanDetail");
            RenameTable(name: "dbo.MonthPlan1", newName: "MonthPlan");
        }
    }
}
