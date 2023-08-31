using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PurchaseOrder")]
[Index("Number", "TenantId", Name = "PurchaseOrderUniqueConstraint", IsUnique = true)]
public partial class PurchaseOrder
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? ProcurementGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    public int? VendorId { get; set; }

    public double SubTotal { get; set; }

    public double Discount { get; set; }

    public double BeforeTax { get; set; }

    public double TaxAmount { get; set; }

    public double Total { get; set; }

    public double OtherCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceipts { get; set; } = new List<PurchaseReceipt>();

    [ForeignKey("VendorId")]
    [InverseProperty("PurchaseOrders")]
    public virtual Vendor Vendor { get; set; } = null!;
}
