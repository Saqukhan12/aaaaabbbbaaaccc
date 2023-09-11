using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PurchaseReceipt")]
[Index("Number", "TenantId", Name = "PurchaseReceiptUniqueConstraint", IsUnique = true)]
public partial class PurchaseReceipt 
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? ExternalReferenceNumber { get; set; }

    [StringLength(200)]
    public string? ProcurementGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReceiptDate { get; set; }

    public int? PurchaseOrderId { get; set; }

    public int? WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public double TotalQtyReceive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("PurchaseReceipts")]
    public virtual Location? Location { get; set; }

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("PurchaseReceipts")]
    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

    [InverseProperty("PurchaseReceipt")]
    public virtual ICollection<PurchaseReceiptDetail> PurchaseReceiptDetails { get; set; } = new List<PurchaseReceiptDetail>();

    [InverseProperty("PurchaseReceipt")]
    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    [ForeignKey("WarehouseId")]
    [InverseProperty("PurchaseReceipts")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
