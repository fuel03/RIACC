using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RIACC.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RIACC.Data
{
    public class DBConnectionContext : DbContext
    {
        static DBConnectionContext()
        {
            Database.SetInitializer<DBConnectionContext>(null);
            //initializer
        }

        public DbSet<AuditTrail> AuditTrail { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<DealerLocation> DealerLocation { get; set; }
        public DbSet<DeliveryOrder> DeliveryOrder { get; set; }
        public DbSet<DeliveryOrderDetail> DeliveryOrderDetail { get; set; }
        public DbSet<DPComponent> DPComponent { get; set; }
        public DbSet<DPComponentDetail> DPComponentDetail { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SuppliersItem> SuppliersItem { get; set; }
        public DbSet<TrackList> TrackList { get; set; }
        public DbSet<TrackListDetail> TrackListDetail { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // disable cascade delete
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<PurchaseOrderDetail>()
            //      .HasRequired(c => c.PurchaseOrder)
            //      .WithMany(o => o.PurchaseOrderDetail)
            //      .HasForeignKey(o => o.POId)
            //      .WillCascadeOnDelete(true);

        }
    }
}
