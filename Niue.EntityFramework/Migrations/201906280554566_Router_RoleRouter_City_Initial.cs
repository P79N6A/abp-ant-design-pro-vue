namespace Niue.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Router_RoleRouter_City_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                        SpellAll = c.String(maxLength: 100),
                        SpellShort = c.String(maxLength: 32),
                        Initial = c.String(maxLength: 10),
                        AmapCityCode = c.String(maxLength: 10),
                        BaiduCityCode = c.String(maxLength: 10),
                        Longitude = c.String(maxLength: 20),
                        Latitude = c.String(maxLength: 20),
                        SchoolSecurityCode = c.Int(nullable: false),
                        Province_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.Province_Id)
                .Index(t => t.Province_Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        Actions = c.String(),
                        IsKeep = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Router_Id = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RolePermission_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routers", t => t.Router_Id)
                .Index(t => t.Router_Id);
            
            CreateTable(
                "dbo.Routers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(maxLength: 50),
                        ParentKey = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Component = c.String(maxLength: 50),
                        Redirect = c.String(),
                        Icon = c.String(maxLength: 20),
                        Sort = c.Int(nullable: false),
                        IsKeep = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Router_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AbpUsers", "Mobile", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.AbpUsers", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.AbpUsers", "WxOpenId", c => c.String());
            AddColumn("dbo.AbpUsers", "IdentificationNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.AbpUsers", "IdentificationPhoto", c => c.String());
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePermissions", "Router_Id", "dbo.Routers");
            DropForeignKey("dbo.Cities", "Province_Id", "dbo.Cities");
            DropIndex("dbo.RolePermissions", new[] { "Router_Id" });
            DropIndex("dbo.Cities", new[] { "Province_Id" });
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.AbpUsers", "IdentificationPhoto");
            DropColumn("dbo.AbpUsers", "IdentificationNumber");
            DropColumn("dbo.AbpUsers", "WxOpenId");
            DropColumn("dbo.AbpUsers", "UserType");
            DropColumn("dbo.AbpUsers", "Mobile");
            DropTable("dbo.Routers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Router_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.RolePermissions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RolePermission_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Cities");
        }
    }
}
