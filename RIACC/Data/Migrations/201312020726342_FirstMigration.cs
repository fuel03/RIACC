namespace RIACC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTrail",
                c => new
                    {
                        AuditId = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TableName = c.String(nullable: false, maxLength: 25),
                        TransactionId = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AuditId)
                .ForeignKey("User", x => x.UserId);

            CreateTable(
                "dbo.Dealer",
                c => new
                    {
                        DealerId = c.Int(nullable: false, identity: true),
                        DealerCode = c.String(nullable: false, maxLength: 50),
                        DealerName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        ContactPerson = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 50),
                        TIN = c.String(maxLength: 20),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DealerId)
                .Index(x => x.DealerCode, unique: true)
                .Index(x => x.DealerName, unique: true);

            CreateTable(
                "dbo.DealerLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DealerId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealer", x => x.DealerId)
                .ForeignKey("dbo.Location", x => x.LocationId);

            CreateTable(
                "dbo.DeliveryOrder",
                c => new
                    {
                        DRId = c.Int(nullable: false, identity: true),
                        DRNumber = c.String(nullable: false, maxLength: 20),
                        DealerId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PreparedBy = c.Int(nullable: false),
                        ApprovedBy = c.Int(),
                        Approved = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DRId);

            CreateTable(
                "dbo.DeliveryOrderDetail",
                c => new
                    {
                        DRDetailId = c.Int(nullable: false, identity: true),
                        DRId = c.Int(nullable: false),
                        POId = c.Int(nullable: false),
                        PODetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DRDetailId)
                .ForeignKey("dbo.DeliveryOrder", t => t.DRId, cascadeDelete: true)
                .Index(t => t.DRId);

            CreateTable(
                "dbo.DPComponent",
                c => new
                    {
                        DPId = c.Int(nullable: false, identity: true),
                        DPNumber = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                        PreparedBy = c.Int(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.DPId);

            CreateTable(
                "dbo.DPComponentDetail",
                c => new
                    {
                        DPDetailId = c.Int(nullable: false, identity: true),
                        DPId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DRDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DPDetailId)
                .ForeignKey("dbo.DPComponent", t => t.DPId, cascadeDelete: true)
                .Index(t => t.DPId);

            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(nullable: false, maxLength: 100),
                        ItemDescription = c.String(nullable: false, maxLength: 100),
                        UnitId = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);

            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false, maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId)
                .Index(x => x.LocationName, unique: true);

            CreateTable(
                "dbo.Module",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ModuleId);

            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PurchaseOrder",
                c => new
                    {
                        POId = c.Int(nullable: false, identity: true),
                        PONumber = c.String(nullable: false, maxLength: 20),
                        SupplierId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SubTotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreparedBy = c.Int(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Discount = c.Double(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.POId);

            CreateTable(
                "dbo.PurchaseOrderDetail",
                c => new
                    {
                        PODetailId = c.Int(nullable: false, identity: true),
                        POId = c.Int(nullable: false),
                        InventoryNumber = c.String(nullable: false, maxLength: 15),
                        ItemId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PODetailId)
                .ForeignKey("dbo.PurchaseOrder", t => t.POId, cascadeDelete: true)
                .Index(t => t.POId);

            CreateTable(
                "dbo.Supplier",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierCode = c.String(nullable: false, maxLength: 100),
                        SupplierName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        ContactPerson = c.String(maxLength: 100),
                        ContactNumber = c.String(maxLength: 50),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);

            CreateTable(
                "dbo.SuppliersItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TrackList",
                c => new
                    {
                        TrackId = c.Int(nullable: false, identity: true),
                        TrackNumber = c.String(nullable: false, maxLength: 20),
                        DRId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PreparedBy = c.Int(nullable: false),
                        RecievedBy = c.String(maxLength: 150),
                        DeliveredBy = c.String(maxLength: 100),
                        Remarks = c.String(maxLength: 500),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrackId);

            CreateTable(
                "dbo.TrackListDetail",
                c => new
                    {
                        TRDetailId = c.Int(nullable: false, identity: true),
                        TrackId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        DRDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TRDetailId)
                .ForeignKey("dbo.TrackList", t => t.TrackId, cascadeDelete: true)
                .Index(t => t.TrackId);

            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false, maxLength: 100),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId);

            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 100),
                        Address = c.String(maxLength: 500),
                        Expiration = c.DateTime(),
                        IsLocked = c.Boolean(nullable: false),
                        IsExpired = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        VoidLoginCount = c.Int(nullable: false),
                        LastLogin = c.DateTime(),
                        ChangePasswordRequest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TrackListDetail", "TrackId", "dbo.TrackList");
            DropForeignKey("dbo.PurchaseOrderDetail", "POId", "dbo.PurchaseOrder");
            DropForeignKey("dbo.DPComponentDetail", "DPId", "dbo.DPComponent");
            DropForeignKey("dbo.DeliveryOrderDetail", "DRId", "dbo.DeliveryOrder");
            DropIndex("dbo.TrackListDetail", new[] { "TrackId" });
            DropIndex("dbo.PurchaseOrderDetail", new[] { "POId" });
            DropIndex("dbo.DPComponentDetail", new[] { "DPId" });
            DropIndex("dbo.DeliveryOrderDetail", new[] { "DRId" });
            DropTable("dbo.User");
            DropTable("dbo.Unit");
            DropTable("dbo.TrackListDetail");
            DropTable("dbo.TrackList");
            DropTable("dbo.SuppliersItem");
            DropTable("dbo.Supplier");
            DropTable("dbo.PurchaseOrderDetail");
            DropTable("dbo.PurchaseOrder");
            DropTable("dbo.Permission");
            DropTable("dbo.Module");
            DropTable("dbo.Location");
            DropTable("dbo.Item");
            DropTable("dbo.DPComponentDetail");
            DropTable("dbo.DPComponent");
            DropTable("dbo.DeliveryOrderDetail");
            DropTable("dbo.DeliveryOrder");
            DropTable("dbo.DealerLocation");
            DropTable("dbo.Dealer");
            DropTable("dbo.AuditTrail");
        }
    }
}
