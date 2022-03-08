namespace WebNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dattiec : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DatTiecs", "ChuRe", c => c.String(nullable: false));
            AddColumn("dbo.DatTiecs", "CoDau", c => c.String(nullable: false));
            AddColumn("dbo.DatTiecs", "NgayDat", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DatTiecs", "NgayDat");
            DropColumn("dbo.DatTiecs", "CoDau");
            DropColumn("dbo.DatTiecs", "ChuRe");
        }
    }
}
