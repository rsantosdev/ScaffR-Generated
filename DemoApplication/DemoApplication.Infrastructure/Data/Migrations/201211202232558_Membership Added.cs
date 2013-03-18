#region credits
// ***********************************************************************
// Assembly	: DemoApplication.Infrastructure
// Author	: Rod Johnson
// Created	: 03-16-2013
// 
// Last Modified By : Rod Johnson
// Last Modified On : 03-17-2013
// ***********************************************************************
#endregion
namespace DemoApplication.Infrastructure.Data.Migrations
{
    #region

    using System.Data.Entity.Migrations;

    #endregion

    public partial class MembershipAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                        Username = c.String(),
                        Password = c.String(),
                        Comment = c.String(),
                        ResetPassword = c.Boolean(),
                        ShowWelcomePage = c.Boolean(),
                        TemporaryPassword = c.String(),
                        PhotoId = c.String(),
                        IsApproved = c.Boolean(),
                        PasswordFailuresSinceLastSuccess = c.Int(),
                        LastPasswordFailureDate = c.DateTime(),
                        LastActivityDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        IsLockedOut = c.Boolean(),
                        LastPasswordChangedDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserEmails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserEmails", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropForeignKey("dbo.UserEmails", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropTable("dbo.UserEmails");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
        }
    }
}
