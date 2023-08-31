using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreBoilerplate.Areas.Identity.Extensions;
using DotNetCoreBoilerplate.Common.BaseEntity;
using DotNetCoreBoilerplate.Identity.Models;
using DotNetCoreBoilerplate.Identity.Models.UserManagment;
using DotNetCoreBoilerplate.Identity.ViewModels;
using DotNetCoreBoilerplate.Models;

namespace DotNetCoreBoilerplate.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession Session => httpContextAccessor.HttpContext.Session;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public virtual DbSet<Bill> Bills { get; set; }

        public virtual DbSet<BillDetail> BillDetails { get; set; }

        public virtual DbSet<BillPayment> BillPayments { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<CashBank> CashBanks { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Colour> Colours { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }

        //public virtual DbSet<Exception> Exceptions { get; set; }

        public virtual DbSet<Flavour> Flavours { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }

        public virtual DbSet<Language> Languages { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<NegativeAdjustment> NegativeAdjustments { get; set; }

        public virtual DbSet<NegativeAdjustmentDetail> NegativeAdjustmentDetails { get; set; }

        public virtual DbSet<PositiveAdjustment> PositiveAdjustments { get; set; }

        public virtual DbSet<PositiveAdjustmentDetail> PositiveAdjustmentDetails { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public virtual DbSet<PurchaseReceipt> PurchaseReceipts { get; set; }

        public virtual DbSet<PurchaseReceiptDetail> PurchaseReceiptDetails { get; set; }

        public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }

        public virtual DbSet<PurchaseReturnDetail> PurchaseReturnDetails { get; set; }

        public virtual DbSet<PurchaseTax> PurchaseTaxes { get; set; }

        //public virtual DbSet<Role> Roles { get; set; }

        //public virtual DbSet<RolePermission> RolePermissions { get; set; }

        public virtual DbSet<SalesChannel> SalesChannels { get; set; }

        public virtual DbSet<SalesDelivery> SalesDeliveries { get; set; }

        public virtual DbSet<SalesDeliveryDetail> SalesDeliveryDetails { get; set; }

        public virtual DbSet<SalesOrder> SalesOrders { get; set; }

        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        public virtual DbSet<SalesReturn> SalesReturns { get; set; }

        public virtual DbSet<SalesReturnDetail> SalesReturnDetails { get; set; }

        public virtual DbSet<SalesTax> SalesTaxes { get; set; }

        public virtual DbSet<Shipper> Shippers { get; set; }

        public virtual DbSet<Size> Sizes { get; set; }

        public virtual DbSet<Tenant> Tenants { get; set; }

        public virtual DbSet<TransferOrder> TransferOrders { get; set; }

        public virtual DbSet<TransferOrderDetail> TransferOrderDetails { get; set; }

        public virtual DbSet<Uom> Uoms { get; set; }

        //public virtual DbSet<User> Users { get; set; }

        //public virtual DbSet<UserPermission> UserPermissions { get; set; }

        //public virtual DbSet<UserPreference> UserPreferences { get; set; }

        //public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Vendor> Vendors { get; set; }

        public virtual DbSet<VendorContact> VendorContacts { get; set; }

        public virtual DbSet<VersionInfo> VersionInfos { get; set; }

        public virtual DbSet<Warehouse> Warehouses { get; set; }
        //Save Chanegs over write automatically add for the models the enherited base entity.
        public async Task<int> SaveChangesAsync()
        {
            var changeSet = this.ChangeTracker.Entries<BaseEntity>();
            var UserDetails = Session.GetObject<ApplicationUserVM>(Startup.UserSessionKey);

            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedBy = UserDetails.ApplicationUserId;
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.UpdatedBy = UserDetails.ApplicationUserId;
                        entry.Entity.UpdatedDate = DateTime.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        var original = this.GenerateOriginalEntity<BaseEntity>(entry.GetDatabaseValues());
                        entry.Entity.UpdatedBy = UserDetails.ApplicationUserId;
                        entry.Entity.UpdatedDate = DateTime.Now;

                        entry.Entity.CreatedDate = original.CreatedDate;
                        entry.Entity.CreatedBy = original.CreatedBy;
                    }
                }
            }
            return await base.SaveChangesAsync();
        }

        private T GenerateOriginalEntity<T>(PropertyValues values) where T : new()
        {
            T entity = new T();
            Type type = typeof(T);
            var baseProperties = type.GetProperties();
            foreach (var property in baseProperties)
            {
                property.SetValue(entity, values[property.Name]);
            }
            return entity;
        }
    }
}