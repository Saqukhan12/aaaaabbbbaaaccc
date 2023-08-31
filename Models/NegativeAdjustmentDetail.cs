using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("NegativeAdjustmentDetail")]
public partial class NegativeAdjustmentDetail
{
    [Key]
    public int Id { get; set; }

    public int? NegativeAdjustmentId { get; set; }

    public int? ProductId { get; set; }

    public double Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("NegativeAdjustmentId")]
    [InverseProperty("NegativeAdjustmentDetails")]
    public virtual NegativeAdjustment NegativeAdjustment { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("NegativeAdjustmentDetails")]
    public virtual Product Product { get; set; } = null!;
}
