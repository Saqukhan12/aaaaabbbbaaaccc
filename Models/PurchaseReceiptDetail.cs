using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("PurchaseReceiptDetail")]
public partial class PurchaseReceiptDetail 
{
    [Key]
    public int Id { get; set; }

    public int? PurchaseReceiptId { get; set; }

    public int? ProductId { get; set; }

    public double QtyReceive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("PurchaseReceiptDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("PurchaseReceiptId")]
    [InverseProperty("PurchaseReceiptDetails")]
    public virtual PurchaseReceipt PurchaseReceipt { get; set; } = null!;
}
