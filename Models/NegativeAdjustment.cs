using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("NegativeAdjustment")]
[Index("Number", "TenantId", Name = "NegativeAdjustmentUniqueConstraint", IsUnique = true)]
public partial class NegativeAdjustment
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime AdjustmentDate { get; set; }

    public int? WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public double TotalQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("NegativeAdjustments")]
    public virtual Location? Location { get; set; }

    [InverseProperty("NegativeAdjustment")]
    public virtual ICollection<NegativeAdjustmentDetail> NegativeAdjustmentDetails { get; set; } = new List<NegativeAdjustmentDetail>();

    [ForeignKey("WarehouseId")]
    [InverseProperty("NegativeAdjustments")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
