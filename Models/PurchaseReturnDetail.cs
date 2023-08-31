using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PurchaseReturnDetail")]
public partial class PurchaseReturnDetail
{
    [Key]
    public int Id { get; set; }

    public int? PurchaseReturnId { get; set; }

    public int? ProductId { get; set; }

    public double QtyReturn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("PurchaseReturnDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("PurchaseReturnId")]
    [InverseProperty("PurchaseReturnDetails")]
    public virtual PurchaseReturn PurchaseReturn { get; set; } = null!;
}
