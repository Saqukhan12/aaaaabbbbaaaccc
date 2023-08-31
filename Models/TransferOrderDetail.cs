using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("TransferOrderDetail")]
public partial class TransferOrderDetail
{
    [Key]
    public int Id { get; set; }

    public int? TransferOrderId { get; set; }

    public int? ProductId { get; set; }

    public double Qty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("TransferOrderDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("TransferOrderId")]
    [InverseProperty("TransferOrderDetails")]
    public virtual TransferOrder TransferOrder { get; set; } = null!;
}
