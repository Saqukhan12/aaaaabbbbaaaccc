using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PositiveAdjustment")]
[Index("Number", "TenantId", Name = "PositiveAdjustmentUniqueConstraint", IsUnique = true)]
public partial class PositiveAdjustment
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
    [InverseProperty("PositiveAdjustments")]
    public virtual Location? Location { get; set; }

    [InverseProperty("PositiveAdjustment")]
    public virtual ICollection<PositiveAdjustmentDetail> PositiveAdjustmentDetails { get; set; } = new List<PositiveAdjustmentDetail>();

    [ForeignKey("WarehouseId")]
    [InverseProperty("PositiveAdjustments")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
