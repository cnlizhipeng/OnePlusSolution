namespace OP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Sex = c.String(maxLength: 2),
                        UPhoto = c.Binary(storeType: "image"),
                        Age = c.Int(),
                        RowGuid = c.Guid(nullable: false),
                        OrganizationID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPwd = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUsers", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.SystemUsers", new[] { "EmployeeID" });
            DropTable("dbo.SystemUsers");
            DropTable("dbo.Employees");
        }
    }
}
