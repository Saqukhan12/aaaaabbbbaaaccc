using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Location")]
[Index("Name", "TenantId", Name = "LocationUniqueConstraint", IsUnique = true)]
public partial class Location
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<NegativeAdjustment> NegativeAdjustments { get; set; } = new List<NegativeAdjustment>();

    [InverseProperty("Location")]
    public virtual ICollection<PositiveAdjustment> PositiveAdjustments { get; set; } = new List<PositiveAdjustment>();

    [InverseProperty("Location")]
    public virtual ICollection<PurchaseReceipt> PurchaseReceipts { get; set; } = new List<PurchaseReceipt>();

    [InverseProperty("Location")]
    public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; } = new List<PurchaseReturn>();

    [InverseProperty("Location")]
    public virtual ICollection<SalesDelivery> SalesDeliveries { get; set; } = new List<SalesDelivery>();

    [InverseProperty("Location")]
    public virtual ICollection<SalesReturn> SalesReturns { get; set; } = new List<SalesReturn>();
}
