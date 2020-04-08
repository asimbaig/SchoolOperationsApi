namespace DatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiLogs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        Host = c.String(),
                        Headers = c.String(),
                        StatusCode = c.String(),
                        TimeUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        RequestBody = c.String(),
                        RequestedMethod = c.String(),
                        UserHostAddress = c.String(),
                        Useragent = c.String(),
                        AbsoluteUri = c.String(),
                        RequestType = c.String(),
                    })
                .PrimaryKey(t => t.LogID);
            
            CreateTable(
                "dbo.AssessmentModels",
                c => new
                    {
                        AssessmentId = c.Int(nullable: false),
                        AssessmentName = c.String(),
                        AssessmentDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        StandardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssessmentId)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.AssessmentId)
                .ForeignKey("dbo.StandardModels", t => t.StandardId, cascadeDelete: true)
                .Index(t => t.AssessmentId)
                .Index(t => t.StandardId);
            
            CreateTable(
                "dbo.ImageFileUrlModels",
                c => new
                    {
                        ImageFileUrlId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        CreateDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        ImageFileTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageFileUrlId)
                .ForeignKey("dbo.ImageFileTypeModels", t => t.ImageFileTypeId, cascadeDelete: true)
                .Index(t => t.ImageFileTypeId);
            
            CreateTable(
                "dbo.AttendanceModels",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false),
                        Present = c.Boolean(nullable: false),
                        AttendanceDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.StudentModels", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.AttendanceId)
                .Index(t => t.AttendanceId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        St_Name = c.String(),
                        EnrolmentDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        St_Address1 = c.String(),
                        St_Address2 = c.String(),
                        St_PostCode = c.String(),
                        St_Telephone = c.String(),
                        St_Email = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(),
                        StandardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.StandardModels", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.StandardId);
            
            CreateTable(
                "dbo.BookTransactionModels",
                c => new
                    {
                        BookTransactionId = c.Int(nullable: false, identity: true),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        ReturnDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookTransactionId)
                .ForeignKey("dbo.BookModels", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.BookModels",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        BookName = c.String(),
                        SerialNumber = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.BookId)
                .Index(t => t.BookId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectModels",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.StandardModels",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StandardId)
                .ForeignKey("dbo.SchoolModels", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.YearModels", t => t.YearId, cascadeDelete: true)
                .Index(t => t.SchoolId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.HomeworkModels",
                c => new
                    {
                        HomeworkId = c.Int(nullable: false),
                        HomeworkName = c.String(),
                        IssueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        DueDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        StandardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HomeworkId)
                .ForeignKey("dbo.StandardModels", t => t.StandardId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.HomeworkId)
                .Index(t => t.HomeworkId)
                .Index(t => t.StandardId);
            
            CreateTable(
                "dbo.SchoolModels",
                c => new
                    {
                        SchoolId = c.Int(nullable: false),
                        SchoolName = c.String(),
                        SchoolAddress1 = c.String(),
                        SchoolAddress2 = c.String(),
                        SchoolPostCode = c.String(),
                        SchoolTelephone = c.String(),
                        SchoolWebsite = c.String(),
                        SchoolEmail = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.SchoolId)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.OperationalStaffModels",
                c => new
                    {
                        OpStaffId = c.Int(nullable: false),
                        OpStaffName = c.String(),
                        OpStaffRole = c.String(),
                        StartDate = c.DateTime(),
                        OpStaffAddress1 = c.String(),
                        OpStaffAddress2 = c.String(),
                        OpStaffPostCode = c.String(),
                        OpStaffTelephone = c.String(),
                        OpStaffEmail = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OpStaffId)
                .ForeignKey("dbo.SchoolModels", t => t.SchoolId, cascadeDelete: true)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.OpStaffId)
                .Index(t => t.OpStaffId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.TeacherModels",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        TeacherName = c.String(),
                        StartDate = c.DateTime(),
                        Tr_Address1 = c.String(),
                        Tr_Address2 = c.String(),
                        Tr_PostCode = c.String(),
                        Tr_Telephone = c.String(),
                        Tr_Email = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.YearModels",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        year = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.YearId);
            
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventId = c.Int(nullable: false),
                        EventName = c.String(),
                        EventDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Location = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.EventId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.ParentModels",
                c => new
                    {
                        ParentId = c.Int(nullable: false),
                        ParentName = c.String(),
                        RelationType = c.String(),
                        ParentAddress1 = c.String(),
                        ParentAddress2 = c.String(),
                        ParentPostCode = c.String(),
                        ParentTelephone = c.String(),
                        ParentEmail = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.ImageFileUrlModels", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ImageFileTypeModels",
                c => new
                    {
                        ImageFileTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ImageFileTypeId);
            
            CreateTable(
                "dbo.ExceptionLoggers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(),
                        ControllerName = c.String(),
                        SourceName = c.String(),
                        ExceptionStackTrace = c.String(),
                        LogTime = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StandardModelSubjectModels",
                c => new
                    {
                        StandardModel_StandardId = c.Int(nullable: false),
                        SubjectModel_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StandardModel_StandardId, t.SubjectModel_SubjectId })
                .ForeignKey("dbo.StandardModels", t => t.StandardModel_StandardId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectModel_SubjectId, cascadeDelete: true)
                .Index(t => t.StandardModel_StandardId)
                .Index(t => t.SubjectModel_SubjectId);
            
            CreateTable(
                "dbo.TeacherModelStandardModels",
                c => new
                    {
                        TeacherModel_TeacherId = c.Int(nullable: false),
                        StandardModel_StandardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherModel_TeacherId, t.StandardModel_StandardId })
                .ForeignKey("dbo.TeacherModels", t => t.TeacherModel_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.StandardModels", t => t.StandardModel_StandardId, cascadeDelete: true)
                .Index(t => t.TeacherModel_TeacherId)
                .Index(t => t.StandardModel_StandardId);
            
            CreateTable(
                "dbo.TeacherModelSubjectModels",
                c => new
                    {
                        TeacherModel_TeacherId = c.Int(nullable: false),
                        SubjectModel_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeacherModel_TeacherId, t.SubjectModel_SubjectId })
                .ForeignKey("dbo.TeacherModels", t => t.TeacherModel_TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectModels", t => t.SubjectModel_SubjectId, cascadeDelete: true)
                .Index(t => t.TeacherModel_TeacherId)
                .Index(t => t.SubjectModel_SubjectId);
            
            CreateTable(
                "dbo.EventModelStudentModels",
                c => new
                    {
                        EventModel_EventId = c.Int(nullable: false),
                        StudentModel_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventModel_EventId, t.StudentModel_StudentId })
                .ForeignKey("dbo.EventModels", t => t.EventModel_EventId, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_StudentId, cascadeDelete: true)
                .Index(t => t.EventModel_EventId)
                .Index(t => t.StudentModel_StudentId);
            
            CreateTable(
                "dbo.ParentModelStudentModels",
                c => new
                    {
                        ParentModel_ParentId = c.Int(nullable: false),
                        StudentModel_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ParentModel_ParentId, t.StudentModel_StudentId })
                .ForeignKey("dbo.ParentModels", t => t.ParentModel_ParentId, cascadeDelete: true)
                .ForeignKey("dbo.StudentModels", t => t.StudentModel_StudentId, cascadeDelete: true)
                .Index(t => t.ParentModel_ParentId)
                .Index(t => t.StudentModel_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssessmentModels", "StandardId", "dbo.StandardModels");
            DropForeignKey("dbo.TeacherModels", "TeacherId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.StudentModels", "StudentId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.SchoolModels", "SchoolId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.ParentModels", "ParentId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.OperationalStaffModels", "OpStaffId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.ImageFileUrlModels", "ImageFileTypeId", "dbo.ImageFileTypeModels");
            DropForeignKey("dbo.HomeworkModels", "HomeworkId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.EventModels", "EventId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.BookModels", "BookId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.AttendanceModels", "AttendanceId", "dbo.ImageFileUrlModels");
            DropForeignKey("dbo.AttendanceModels", "StudentId", "dbo.StudentModels");
            DropForeignKey("dbo.StudentModels", "StandardId", "dbo.StandardModels");
            DropForeignKey("dbo.ParentModelStudentModels", "StudentModel_StudentId", "dbo.StudentModels");
            DropForeignKey("dbo.ParentModelStudentModels", "ParentModel_ParentId", "dbo.ParentModels");
            DropForeignKey("dbo.EventModelStudentModels", "StudentModel_StudentId", "dbo.StudentModels");
            DropForeignKey("dbo.EventModelStudentModels", "EventModel_EventId", "dbo.EventModels");
            DropForeignKey("dbo.BookTransactionModels", "StudentId", "dbo.StudentModels");
            DropForeignKey("dbo.BookTransactionModels", "BookId", "dbo.BookModels");
            DropForeignKey("dbo.BookModels", "SubjectId", "dbo.SubjectModels");
            DropForeignKey("dbo.StandardModels", "YearId", "dbo.YearModels");
            DropForeignKey("dbo.TeacherModelSubjectModels", "SubjectModel_SubjectId", "dbo.SubjectModels");
            DropForeignKey("dbo.TeacherModelSubjectModels", "TeacherModel_TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.TeacherModelStandardModels", "StandardModel_StandardId", "dbo.StandardModels");
            DropForeignKey("dbo.TeacherModelStandardModels", "TeacherModel_TeacherId", "dbo.TeacherModels");
            DropForeignKey("dbo.StandardModelSubjectModels", "SubjectModel_SubjectId", "dbo.SubjectModels");
            DropForeignKey("dbo.StandardModelSubjectModels", "StandardModel_StandardId", "dbo.StandardModels");
            DropForeignKey("dbo.StandardModels", "SchoolId", "dbo.SchoolModels");
            DropForeignKey("dbo.OperationalStaffModels", "SchoolId", "dbo.SchoolModels");
            DropForeignKey("dbo.HomeworkModels", "StandardId", "dbo.StandardModels");
            DropForeignKey("dbo.AssessmentModels", "AssessmentId", "dbo.ImageFileUrlModels");
            DropIndex("dbo.ParentModelStudentModels", new[] { "StudentModel_StudentId" });
            DropIndex("dbo.ParentModelStudentModels", new[] { "ParentModel_ParentId" });
            DropIndex("dbo.EventModelStudentModels", new[] { "StudentModel_StudentId" });
            DropIndex("dbo.EventModelStudentModels", new[] { "EventModel_EventId" });
            DropIndex("dbo.TeacherModelSubjectModels", new[] { "SubjectModel_SubjectId" });
            DropIndex("dbo.TeacherModelSubjectModels", new[] { "TeacherModel_TeacherId" });
            DropIndex("dbo.TeacherModelStandardModels", new[] { "StandardModel_StandardId" });
            DropIndex("dbo.TeacherModelStandardModels", new[] { "TeacherModel_TeacherId" });
            DropIndex("dbo.StandardModelSubjectModels", new[] { "SubjectModel_SubjectId" });
            DropIndex("dbo.StandardModelSubjectModels", new[] { "StandardModel_StandardId" });
            DropIndex("dbo.ParentModels", new[] { "ParentId" });
            DropIndex("dbo.EventModels", new[] { "EventId" });
            DropIndex("dbo.TeacherModels", new[] { "TeacherId" });
            DropIndex("dbo.OperationalStaffModels", new[] { "SchoolId" });
            DropIndex("dbo.OperationalStaffModels", new[] { "OpStaffId" });
            DropIndex("dbo.SchoolModels", new[] { "SchoolId" });
            DropIndex("dbo.HomeworkModels", new[] { "StandardId" });
            DropIndex("dbo.HomeworkModels", new[] { "HomeworkId" });
            DropIndex("dbo.StandardModels", new[] { "YearId" });
            DropIndex("dbo.StandardModels", new[] { "SchoolId" });
            DropIndex("dbo.BookModels", new[] { "SubjectId" });
            DropIndex("dbo.BookModels", new[] { "BookId" });
            DropIndex("dbo.BookTransactionModels", new[] { "StudentId" });
            DropIndex("dbo.BookTransactionModels", new[] { "BookId" });
            DropIndex("dbo.StudentModels", new[] { "StandardId" });
            DropIndex("dbo.StudentModels", new[] { "StudentId" });
            DropIndex("dbo.AttendanceModels", new[] { "StudentId" });
            DropIndex("dbo.AttendanceModels", new[] { "AttendanceId" });
            DropIndex("dbo.ImageFileUrlModels", new[] { "ImageFileTypeId" });
            DropIndex("dbo.AssessmentModels", new[] { "StandardId" });
            DropIndex("dbo.AssessmentModels", new[] { "AssessmentId" });
            DropTable("dbo.ParentModelStudentModels");
            DropTable("dbo.EventModelStudentModels");
            DropTable("dbo.TeacherModelSubjectModels");
            DropTable("dbo.TeacherModelStandardModels");
            DropTable("dbo.StandardModelSubjectModels");
            DropTable("dbo.ExceptionLoggers");
            DropTable("dbo.ImageFileTypeModels");
            DropTable("dbo.ParentModels");
            DropTable("dbo.EventModels");
            DropTable("dbo.YearModels");
            DropTable("dbo.TeacherModels");
            DropTable("dbo.OperationalStaffModels");
            DropTable("dbo.SchoolModels");
            DropTable("dbo.HomeworkModels");
            DropTable("dbo.StandardModels");
            DropTable("dbo.SubjectModels");
            DropTable("dbo.BookModels");
            DropTable("dbo.BookTransactionModels");
            DropTable("dbo.StudentModels");
            DropTable("dbo.AttendanceModels");
            DropTable("dbo.ImageFileUrlModels");
            DropTable("dbo.AssessmentModels");
            DropTable("dbo.ApiLogs");
        }
    }
}
