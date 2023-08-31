using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PositiveAdjustmentDetail")]
public partial class PositiveAdjustmentDetail
{
    [Key]
    public int Id { get; set; }

    public int? PositiveAdjustmentId { get; set; }

    public int? ProductId { get; set; }

    public double Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("PositiveAdjustmentId")]
    [InverseProperty("PositiveAdjustmentDetails")]
    public virtual PositiveAdjustment PositiveAdjustment { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("PositiveAdjustmentDetails")]
    public virtual Product Product { get; set; } = null!;
}
