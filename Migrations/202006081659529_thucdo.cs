namespace WebNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thucdo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Menus", "GiaMenu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "GiaMenu", c => c.Int(nullable: false));
        }
    }
}
