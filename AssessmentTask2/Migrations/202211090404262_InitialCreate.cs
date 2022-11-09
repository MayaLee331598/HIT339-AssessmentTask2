namespace AssessmentTask2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        DoB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        ParentOrGaurdian = c.String(),
                        PaymentEmail = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        InstrumentId = c.Int(nullable: false),
                        TutorId = c.Int(nullable: false),
                        LessonDate = c.DateTime(nullable: false),
                        LessonTime = c.DateTime(nullable: false),
                        DurationId = c.Int(nullable: false),
                        LetterId = c.Int(),
                        Letter_LetterId = c.Int(),
                        Letter_LetterId1 = c.Int(),
                    })
                .PrimaryKey(t => t.LessonId)
                .ForeignKey("dbo.Durations", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.Instruments", t => t.InstrumentId, cascadeDelete: true)
                .ForeignKey("dbo.Letters", t => t.Letter_LetterId)
                .ForeignKey("dbo.Letters", t => t.Letter_LetterId1)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Tutors", t => t.TutorId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.InstrumentId)
                .Index(t => t.TutorId)
                .Index(t => t.DurationId)
                .Index(t => t.Letter_LetterId)
                .Index(t => t.Letter_LetterId1);
            
            CreateTable(
                "dbo.Durations",
                c => new
                    {
                        DurationId = c.Int(nullable: false, identity: true),
                        TimeTaken = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DurationId);
            
            CreateTable(
                "dbo.Instruments",
                c => new
                    {
                        InstrumentId = c.Int(nullable: false, identity: true),
                        InstrumentName = c.String(),
                        InstrumentFamily = c.String(),
                    })
                .PrimaryKey(t => t.InstrumentId);
            
            CreateTable(
                "dbo.Letters",
                c => new
                    {
                        LetterId = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        Beginning_Comment = c.String(),
                        Signiture = c.String(),
                        Bank = c.String(),
                        Account_Name = c.String(),
                        BSB = c.String(),
                        Account_Number = c.String(),
                        Term_Start_Date = c.DateTime(nullable: false),
                        Term_End_Date = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        LessonId = c.Int(nullable: false),
                        Lesson_LessonId = c.Int(),
                        Lesson_LessonId1 = c.Int(),
                    })
                .PrimaryKey(t => t.LetterId)
                .ForeignKey("dbo.Lessons", t => t.Lesson_LessonId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.Lesson_LessonId1)
                .Index(t => t.StudentId)
                .Index(t => t.Lesson_LessonId)
                .Index(t => t.Lesson_LessonId1);
            
            CreateTable(
                "dbo.Tutors",
                c => new
                    {
                        TutorId = c.Int(nullable: false, identity: true),
                        TutorName = c.String(),
                    })
                .PrimaryKey(t => t.TutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "TutorId", "dbo.Tutors");
            DropForeignKey("dbo.Lessons", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Letters", "Lesson_LessonId1", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "Letter_LetterId1", "dbo.Letters");
            DropForeignKey("dbo.Letters", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Lessons", "Letter_LetterId", "dbo.Letters");
            DropForeignKey("dbo.Letters", "Lesson_LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "InstrumentId", "dbo.Instruments");
            DropForeignKey("dbo.Lessons", "DurationId", "dbo.Durations");
            DropIndex("dbo.Letters", new[] { "Lesson_LessonId1" });
            DropIndex("dbo.Letters", new[] { "Lesson_LessonId" });
            DropIndex("dbo.Letters", new[] { "StudentId" });
            DropIndex("dbo.Lessons", new[] { "Letter_LetterId1" });
            DropIndex("dbo.Lessons", new[] { "Letter_LetterId" });
            DropIndex("dbo.Lessons", new[] { "DurationId" });
            DropIndex("dbo.Lessons", new[] { "TutorId" });
            DropIndex("dbo.Lessons", new[] { "InstrumentId" });
            DropIndex("dbo.Lessons", new[] { "StudentId" });
            DropTable("dbo.Tutors");
            DropTable("dbo.Letters");
            DropTable("dbo.Instruments");
            DropTable("dbo.Durations");
            DropTable("dbo.Lessons");
            DropTable("dbo.Students");
        }
    }
}
