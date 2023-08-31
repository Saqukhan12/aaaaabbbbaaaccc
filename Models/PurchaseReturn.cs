using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PurchaseReturn")]
[Index("Number", "TenantId", Name = "PurchaseReturnUniqueConstraint", IsUnique = true)]
public partial class PurchaseReturn
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
    public DateTime ReturnDate { get; set; }

    public int? PurchaseReceiptId { get; set; }

    public int? WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public double TotalQtyReturn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("PurchaseReturns")]
    public virtual Location? Location { get; set; }

    [ForeignKey("PurchaseReceiptId")]
    [InverseProperty("PurchaseReturns")]
    public virtual PurchaseReceipt PurchaseReceipt { get; set; } = null!;

    [InverseProperty("PurchaseReturn")]
    public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; set; } = new List<PurchaseReturnDetail>();

    [ForeignKey("WarehouseId")]
    [InverseProperty("PurchaseReturns")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
