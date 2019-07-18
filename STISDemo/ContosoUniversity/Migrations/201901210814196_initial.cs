namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            /*
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Department", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Person", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(),
                        EnrollmentDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Person", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.MonthPlan",
                c => new
                    {
                        MonthPlanID = c.String(nullable: false, maxLength: 128),
                        MonthOf = c.String(),
                    })
                .PrimaryKey(t => t.MonthPlanID);
            
            CreateTable(
                "dbo.MonthPlanDetail",
                c => new
                    {
                        MonthPlanDetailID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Schedule_ScheduleID = c.String(maxLength: 128),
                        MonthPlan_MonthPlanID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MonthPlanDetailID)
                .ForeignKey("dbo.Schedule", t => t.Schedule_ScheduleID)
                .ForeignKey("dbo.MonthPlan", t => t.MonthPlan_MonthPlanID)
                .Index(t => t.Schedule_ScheduleID)
                .Index(t => t.MonthPlan_MonthPlanID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleID = c.String(nullable: false, maxLength: 128),
                        SelectedTimeSlot_TimeSlotID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.TimeSlot", t => t.SelectedTimeSlot_TimeSlotID)
                .Index(t => t.SelectedTimeSlot_TimeSlotID);
            
            CreateTable(
                "dbo.ScheduleDetail",
                c => new
                    {
                        ScheduleDetailID = c.Int(nullable: false, identity: true),
                        Schedule_ScheduleID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ScheduleDetailID)
                .ForeignKey("dbo.Schedule", t => t.Schedule_ScheduleID)
                .Index(t => t.Schedule_ScheduleID);
            
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
                "dbo.PlayListDetail",
                c => new
                    {
                        PlayListDetailID = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Media_PlayMediaID = c.Int(),
                        PlayList_PlayListID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PlayListDetailID)
                .ForeignKey("dbo.PlayMedia", t => t.Media_PlayMediaID)
                .ForeignKey("dbo.PlayList", t => t.PlayList_PlayListID)
                .Index(t => t.Media_PlayMediaID)
                .Index(t => t.PlayList_PlayListID);
            
            CreateTable(
                "dbo.PlayMedia",
                c => new
                    {
                        PlayMediaID = c.Int(nullable: false, identity: true),
                        MediaType = c.Int(nullable: false),
                        FilePath = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayMediaID);
            
            CreateTable(
                "dbo.TimeSlot",
                c => new
                    {
                        TimeSlotID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TimeSlotID);
            
            CreateTable(
                "dbo.TimeSlotDetail",
                c => new
                    {
                        TimeSlotDetailID = c.Int(nullable: false, identity: true),
                        SlotName = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        ActualStartTime = c.String(),
                        ActualEndTime = c.String(),
                        Duration = c.String(),
                        TimeSlot_TimeSlotID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TimeSlotDetailID)
                .ForeignKey("dbo.TimeSlot", t => t.TimeSlot_TimeSlotID)
                .Index(t => t.TimeSlot_TimeSlotID);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorID);
            
            CreateStoredProcedure(
                "dbo.Department_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Department]([Name], [Budget], [StartDate], [InstructorID])
                      VALUES (@Name, @Budget, @StartDate, @InstructorID)
                      
                      DECLARE @DepartmentID int
                      SELECT @DepartmentID = [DepartmentID]
                      FROM [dbo].[Department]
                      WHERE @@ROWCOUNT > 0 AND [DepartmentID] = scope_identity()
                      
                      SELECT t0.[DepartmentID], t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Update",
                p => new
                    {
                        DepartmentID = p.Int(),
                        Name = p.String(maxLength: 50),
                        Budget = p.Decimal(precision: 19, scale: 4, storeType: "money"),
                        StartDate = p.DateTime(),
                        InstructorID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[Department]
                      SET [Name] = @Name, [Budget] = @Budget, [StartDate] = @StartDate, [InstructorID] = @InstructorID
                      WHERE (([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [dbo].[Department] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentID] = @DepartmentID"
            );
            
            CreateStoredProcedure(
                "dbo.Department_Delete",
                p => new
                    {
                        DepartmentID = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Department]
                      WHERE (([DepartmentID] = @DepartmentID) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))"
            );
            */
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Department_Delete");
            DropStoredProcedure("dbo.Department_Update");
            DropStoredProcedure("dbo.Department_Insert");
            DropForeignKey("dbo.MonthPlanDetail", "MonthPlan_MonthPlanID", "dbo.MonthPlan");
            DropForeignKey("dbo.MonthPlanDetail", "Schedule_ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.Schedule", "SelectedTimeSlot_TimeSlotID", "dbo.TimeSlot");
            DropForeignKey("dbo.TimeSlotDetail", "TimeSlot_TimeSlotID", "dbo.TimeSlot");
            DropForeignKey("dbo.ScheduleDetail", "Schedule_ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.TimeSlotPlayList", "ScheduleDetail_ScheduleDetailID", "dbo.ScheduleDetail");
            DropForeignKey("dbo.TimeSlotPlayList", "PlayList_PlayListID", "dbo.PlayList");
            DropForeignKey("dbo.PlayListDetail", "PlayList_PlayListID", "dbo.PlayList");
            DropForeignKey("dbo.PlayListDetail", "Media_PlayMediaID", "dbo.PlayMedia");
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Person");
            DropForeignKey("dbo.Enrollment", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "InstructorID", "dbo.Person");
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Person");
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.TimeSlotDetail", new[] { "TimeSlot_TimeSlotID" });
            DropIndex("dbo.PlayListDetail", new[] { "PlayList_PlayListID" });
            DropIndex("dbo.PlayListDetail", new[] { "Media_PlayMediaID" });
            DropIndex("dbo.TimeSlotPlayList", new[] { "ScheduleDetail_ScheduleDetailID" });
            DropIndex("dbo.TimeSlotPlayList", new[] { "PlayList_PlayListID" });
            DropIndex("dbo.ScheduleDetail", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Schedule", new[] { "SelectedTimeSlot_TimeSlotID" });
            DropIndex("dbo.MonthPlanDetail", new[] { "MonthPlan_MonthPlanID" });
            DropIndex("dbo.MonthPlanDetail", new[] { "Schedule_ScheduleID" });
            DropIndex("dbo.Enrollment", new[] { "StudentID" });
            DropIndex("dbo.Enrollment", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.Department", new[] { "InstructorID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.TimeSlotDetail");
            DropTable("dbo.TimeSlot");
            DropTable("dbo.PlayMedia");
            DropTable("dbo.PlayListDetail");
            DropTable("dbo.PlayList");
            DropTable("dbo.TimeSlotPlayList");
            DropTable("dbo.ScheduleDetail");
            DropTable("dbo.Schedule");
            DropTable("dbo.MonthPlanDetail");
            DropTable("dbo.MonthPlan");
            DropTable("dbo.Enrollment");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Person");
            DropTable("dbo.Department");
            DropTable("dbo.Course");
        }
    }
}
