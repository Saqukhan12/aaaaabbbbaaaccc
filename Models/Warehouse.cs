using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Warehouse")]
[Index("Name", "TenantId", Name = "WarehouseUniqueConstraint", IsUnique = true)]
public partial class Warehouse 
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? Street { get; set; }

    [StringLength(200)]
    public string? City { get; set; }

    [StringLength(200)]
    public string? State { get; set; }

    [StringLength(10)]
    public string? ZipCode { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("Warehouse")]
    public virtual ICollection<NegativeAdjustment> NegativeAdjustments { get; set; } = new List<NegativeAdjustment>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<PositiveAdjustment> PositiveAdjustments { get; set; } = new List<PositiveAdjustment>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceipts { get; set; } = new List<PurchaseReceipt>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<SalesDelivery> SalesDeliveries { get; set; } = new List<SalesDelivery>();

    [InverseProperty("Warehouse")]
    public virtual ICollection<SalesReturn> SalesReturns { get; set; } = new List<SalesReturn>();

    [InverseProperty("From")]
    public virtual ICollection<TransferOrder> TransferOrderFroms { get; set; } = new List<TransferOrder>();

    [InverseProperty("To")]
    public virtual ICollection<TransferOrder> TransferOrderTos { get; set; } = new List<TransferOrder>();
}
