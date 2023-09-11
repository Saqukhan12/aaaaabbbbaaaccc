using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesDeliveryDetail")]
public partial class SalesDeliveryDetail 
{
    [Key]
    public int Id { get; set; }

    public int? SalesDeliveryId { get; set; }

    public int? ProductId { get; set; }

    public double QtyDelivered { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SalesDeliveryDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SalesDeliveryId")]
    [InverseProperty("SalesDeliveryDetails")]
    public virtual SalesDelivery SalesDelivery { get; set; } = null!;
}
