namespace QZCHY.PanoramaQuzhou.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityLogTypeId = c.Int(nullable: false),
                        AccountUserId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountUsers", t => t.AccountUserId, cascadeDelete: true)
                .ForeignKey("dbo.ActivityLogTypes", t => t.ActivityLogTypeId, cascadeDelete: true)
                .Index(t => t.ActivityLogTypeId)
                .Index(t => t.AccountUserId);
            
            CreateTable(
                "dbo.AccountUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DDUserId = c.String(),
                        NickName = c.String(),
                        AccountUserGuid = c.Guid(nullable: false),
                        LastIpAddress = c.String(),
                        LastActivityDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        DingdingToken = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ActivityLogTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SystemKeyword = c.String(nullable: false, maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 200),
                        Enabled = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogLevelId = c.Int(nullable: false),
                        ShortMessage = c.String(nullable: false),
                        FullMessage = c.String(),
                        IpAddress = c.String(maxLength: 200),
                        CustomerId = c.Int(),
                        PageUrl = c.String(),
                        ReferrerUrl = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountUsers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.PanoramaLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LogoUrl = c.String(),
                        Region = c.String(),
                        Lng = c.Double(nullable: false),
                        Lat = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        IsProject = c.Boolean(nullable: false),
                        DefaultPanoramaSceneId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PanoramaPanoramaScenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LogoUrl = c.String(),
                        ThumPath = c.String(),
                        Views = c.Int(nullable: false),
                        Stars = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        LastViewDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PanoramaLocations", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Remark = c.String(),
                        LogoUrl = c.String(),
                        Order = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PanoramaScene_Tags_Mapping",
                c => new
                    {
                        PanoramaScene_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PanoramaScene_Id, t.Tag_Id })
                .ForeignKey("dbo.PanoramaPanoramaScenes", t => t.PanoramaScene_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.PanoramaScene_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.PonoramaLocation_PanoramaScene_Mapping",
                c => new
                    {
                        PanoramaLocation_Id = c.Int(nullable: false),
                        PanoramaScene_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PanoramaLocation_Id, t.PanoramaScene_Id })
                .ForeignKey("dbo.PanoramaLocations", t => t.PanoramaLocation_Id, cascadeDelete: true)
                .ForeignKey("dbo.PanoramaPanoramaScenes", t => t.PanoramaScene_Id, cascadeDelete: true)
                .Index(t => t.PanoramaLocation_Id)
                .Index(t => t.PanoramaScene_Id);
            
            CreateTable(
                "dbo.PonoramaLocation_Tag_Mapping",
                c => new
                    {
                        PanoramaLocation_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PanoramaLocation_Id, t.Tag_Id })
                .ForeignKey("dbo.PanoramaLocations", t => t.PanoramaLocation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.PanoramaLocation_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.Project_PonoramaLocation_Mapping",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        PanoramaLocation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.PanoramaLocation_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.PanoramaLocations", t => t.PanoramaLocation_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.PanoramaLocation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project_PonoramaLocation_Mapping", "PanoramaLocation_Id", "dbo.PanoramaLocations");
            DropForeignKey("dbo.Project_PonoramaLocation_Mapping", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.PonoramaLocation_Tag_Mapping", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.PonoramaLocation_Tag_Mapping", "PanoramaLocation_Id", "dbo.PanoramaLocations");
            DropForeignKey("dbo.PonoramaLocation_PanoramaScene_Mapping", "PanoramaScene_Id", "dbo.PanoramaPanoramaScenes");
            DropForeignKey("dbo.PonoramaLocation_PanoramaScene_Mapping", "PanoramaLocation_Id", "dbo.PanoramaLocations");
            DropForeignKey("dbo.PanoramaScene_Tags_Mapping", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.PanoramaScene_Tags_Mapping", "PanoramaScene_Id", "dbo.PanoramaPanoramaScenes");
            DropForeignKey("dbo.PanoramaPanoramaScenes", "Location_Id", "dbo.PanoramaLocations");
            DropForeignKey("dbo.Logs", "CustomerId", "dbo.AccountUsers");
            DropForeignKey("dbo.ActivityLogs", "ActivityLogTypeId", "dbo.ActivityLogTypes");
            DropForeignKey("dbo.ActivityLogs", "AccountUserId", "dbo.AccountUsers");
            DropIndex("dbo.Project_PonoramaLocation_Mapping", new[] { "PanoramaLocation_Id" });
            DropIndex("dbo.Project_PonoramaLocation_Mapping", new[] { "Project_Id" });
            DropIndex("dbo.PonoramaLocation_Tag_Mapping", new[] { "Tag_Id" });
            DropIndex("dbo.PonoramaLocation_Tag_Mapping", new[] { "PanoramaLocation_Id" });
            DropIndex("dbo.PonoramaLocation_PanoramaScene_Mapping", new[] { "PanoramaScene_Id" });
            DropIndex("dbo.PonoramaLocation_PanoramaScene_Mapping", new[] { "PanoramaLocation_Id" });
            DropIndex("dbo.PanoramaScene_Tags_Mapping", new[] { "Tag_Id" });
            DropIndex("dbo.PanoramaScene_Tags_Mapping", new[] { "PanoramaScene_Id" });
            DropIndex("dbo.PanoramaPanoramaScenes", new[] { "Location_Id" });
            DropIndex("dbo.Logs", new[] { "CustomerId" });
            DropIndex("dbo.ActivityLogs", new[] { "AccountUserId" });
            DropIndex("dbo.ActivityLogs", new[] { "ActivityLogTypeId" });
            DropTable("dbo.Project_PonoramaLocation_Mapping");
            DropTable("dbo.PonoramaLocation_Tag_Mapping");
            DropTable("dbo.PonoramaLocation_PanoramaScene_Mapping");
            DropTable("dbo.PanoramaScene_Tags_Mapping");
            DropTable("dbo.Projects");
            DropTable("dbo.Tags");
            DropTable("dbo.PanoramaPanoramaScenes");
            DropTable("dbo.PanoramaLocations");
            DropTable("dbo.Logs");
            DropTable("dbo.ActivityLogTypes");
            DropTable("dbo.AccountUsers");
            DropTable("dbo.ActivityLogs");
        }
    }
}
