using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesReturn")]
[Index("Number", "TenantId", Name = "SalesReturnUniqueConstraint", IsUnique = true)]
public partial class SalesReturn 
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
    public DateTime ReturnDate { get; set; }

    public int? SalesDeliveryId { get; set; }

    public int? WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public double TotalQtyReturn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("SalesReturns")]
    public virtual Location? Location { get; set; }

    [ForeignKey("SalesDeliveryId")]
    [InverseProperty("SalesReturns")]
    public virtual SalesDelivery SalesDelivery { get; set; } = null!;

    [InverseProperty("SalesReturn")]
    public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; } = new List<SalesReturnDetail>();

    [ForeignKey("WarehouseId")]
    [InverseProperty("SalesReturns")]
    public virtual Warehouse Warehouse { get; set; } = null!;
}
