namespace WebNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class snh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatTiecs",
                c => new
                    {
                        TiecID = c.Int(nullable: false, identity: true),
                        SoBan = c.Int(nullable: false),
                        GiaTiec = c.Int(nullable: false),
                        MenuID = c.Int(nullable: false),
                        SanhID = c.Int(nullable: false),
                        KhachID = c.Int(nullable: false),
                        DichVuID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TiecID)
                .ForeignKey("dbo.DichVus", t => t.DichVuID, cascadeDelete: true)
                .ForeignKey("dbo.KhachHangs", t => t.KhachID, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.MenuID, cascadeDelete: true)
                .ForeignKey("dbo.Sanhs", t => t.SanhID, cascadeDelete: true)
                .Index(t => t.MenuID)
                .Index(t => t.SanhID)
                .Index(t => t.KhachID)
                .Index(t => t.DichVuID);
            
            CreateTable(
                "dbo.DichVus",
                c => new
                    {
                        DichVuID = c.Int(nullable: false, identity: true),
                        TenDichVu = c.String(nullable: false),
                        HinhThuc = c.String(nullable: false),
                        GiaDichVu = c.Int(nullable: false),
                        HinhDichVu = c.String(),
                    })
                .PrimaryKey(t => t.DichVuID);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        KhachID = c.Int(nullable: false, identity: true),
                        TenKhach = c.String(nullable: false),
                        SDT = c.Int(nullable: false),
                        DiaChi = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KhachID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        TenMenu = c.String(nullable: false),
                        GiaMenu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Sanhs",
                c => new
                    {
                        SanhID = c.Int(nullable: false, identity: true),
                        TenSanh = c.String(nullable: false),
                        MoTa = c.String(nullable: false),
                        HinhSanh = c.String(),
                    })
                .PrimaryKey(t => t.SanhID);
            
            CreateTable(
                "dbo.MonAns",
                c => new
                    {
                        MonAnID = c.Int(nullable: false, identity: true),
                        TenMonAn = c.String(nullable: false),
                        GiaMonAn = c.Int(nullable: false),
                        HinhMonAn = c.String(),
                        MenuID = c.Int(),
                    })
                .PrimaryKey(t => t.MonAnID)
                .ForeignKey("dbo.Menus", t => t.MenuID)
                .Index(t => t.MenuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonAns", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.DatTiecs", "SanhID", "dbo.Sanhs");
            DropForeignKey("dbo.DatTiecs", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.DatTiecs", "KhachID", "dbo.KhachHangs");
            DropForeignKey("dbo.DatTiecs", "DichVuID", "dbo.DichVus");
            DropIndex("dbo.MonAns", new[] { "MenuID" });
            DropIndex("dbo.DatTiecs", new[] { "DichVuID" });
            DropIndex("dbo.DatTiecs", new[] { "KhachID" });
            DropIndex("dbo.DatTiecs", new[] { "SanhID" });
            DropIndex("dbo.DatTiecs", new[] { "MenuID" });
            DropTable("dbo.MonAns");
            DropTable("dbo.Sanhs");
            DropTable("dbo.Menus");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.DichVus");
            DropTable("dbo.DatTiecs");
        }
    }
}
