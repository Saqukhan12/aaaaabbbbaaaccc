using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesOrder")]
[Index("Number", "TenantId", Name = "SalesOrderUniqueConstraint", IsUnique = true)]
public partial class SalesOrder
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
    public DateTime OrderDate { get; set; }

    public int? CustomerId { get; set; }

    public int? SalesChannelId { get; set; }

    public double SubTotal { get; set; }

    public double Discount { get; set; }

    public double BeforeTax { get; set; }

    public double TaxAmount { get; set; }

    public double Total { get; set; }

    public double OtherCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("SalesOrders")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("SalesOrder")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [ForeignKey("SalesChannelId")]
    [InverseProperty("SalesOrders")]
    public virtual SalesChannel SalesChannel { get; set; } = null!;

    [InverseProperty("SalesOrder")]
    public virtual ICollection<SalesDelivery> SalesDeliveries { get; set; } = new List<SalesDelivery>();

    [InverseProperty("SalesOrder")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
