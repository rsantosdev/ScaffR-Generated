namespace DemoApplication.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserClaims : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Created = c.DateTime(),
                        RowVersion = c.Binary(),
                        Updated = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
