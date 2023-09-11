using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesDelivery")]
[Index("Number", "TenantId", Name = "SalesDeliveryUniqueConstraint", IsUnique = true)]
public partial class SalesDelivery 
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? SalesGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DeliveryDate { get; set; }

    public int? SalesOrderId { get; set; }

    public int? ShipperId { get; set; }

    public int? WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public double TotalQtyDelivered { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("SalesDeliveries")]
    public virtual Location? Location { get; set; }

    [InverseProperty("SalesDelivery")]
    public virtual ICollection<SalesDeliveryDetail> SalesDeliveryDetails { get; set; } = new List<SalesDeliveryDetail>();

    [ForeignKey("SalesOrderId")]
    [InverseProperty("SalesDeliveries")]
    public virtual SalesOrder SalesOrder { get; set; } = null!;

    [InverseProperty("SalesDelivery")]
    public virtual ICollection<SalesReturn> SalesReturns { get; set; } = new List<SalesReturn>();

    [ForeignKey("ShipperId")]
    [InverseProperty("SalesDeliveries")]
    public virtual Shipper Shipper { get; set; } = null!;

    [ForeignKey("WarehouseId")]
    [InverseProperty("SalesDeliveries")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
