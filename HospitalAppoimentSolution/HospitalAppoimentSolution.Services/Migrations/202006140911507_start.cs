namespace HospitalAppoimentSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appoinments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 16),
                        Patient = c.Int(nullable: false),
                        Doctor = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(maxLength: 20),
                        Status = c.Int(nullable: false),
                        IsPayment = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        Reduce = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AssignPositions",
                c => new
                    {
                        StaffID = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Desc = c.String(),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StaffID, t.PositionID, t.DepartmentID });
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        Phone = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 150),
                        IsMedicalExam = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Avatar = c.String(maxLength: 500),
                        BirthDay = c.String(maxLength: 250),
                        Address = c.String(maxLength: 850),
                        Phone = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Department = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DoctorSchedules",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Shift = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Day });
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Comment = c.String(maxLength: 550),
                        Member = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        ViewNumber = c.Int(nullable: false),
                        MetaTitle = c.String(maxLength: 60),
                        MetaDesc = c.String(maxLength: 160),
                        MetaKeyword = c.String(maxLength: 260),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        BirthDay = c.String(maxLength: 250),
                        Address = c.String(maxLength: 850),
                        Phone = c.String(maxLength: 250),
                        Email = c.String(maxLength: 250),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        Desc = c.String(maxLength: 550),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Code = c.String(maxLength: 12),
                        Title = c.String(maxLength: 250),
                        Avatar = c.String(),
                        Desc = c.String(maxLength: 350),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DoctorApply = c.String(),
                        AmountReduced = c.Int(nullable: false),
                        PercentReduced = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShiftTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.String(maxLength: 50),
                        EndTime = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Address = c.String(maxLength: 350),
                        BirthDay = c.DateTime(),
                        Phone = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Account = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        CreateDate = c.DateTime(),
                        CreateBy = c.String(),
                        ModifyDate = c.DateTime(),
                        ModifyBy = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
            DropTable("dbo.ShiftTimes");
            DropTable("dbo.Promotions");
            DropTable("dbo.Positions");
            DropTable("dbo.Patients");
            DropTable("dbo.News");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.DoctorSchedules");
            DropTable("dbo.Doctors");
            DropTable("dbo.Departments");
            DropTable("dbo.AssignPositions");
            DropTable("dbo.Appoinments");
        }
    }
}
