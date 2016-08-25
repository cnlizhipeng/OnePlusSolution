namespace OP.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysModules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PID = c.Int(nullable: false),
                        KeyGuid = c.Guid(nullable: false),
                        ModuleName = c.String(),
                        ViewOrder = c.Int(nullable: false),
                        Web = c.Boolean(nullable: false),
                        Cs = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysModules");
        }
    }
}
