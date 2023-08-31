using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Bill")]
[Index("Number", "TenantId", Name = "BillUniqueConstraint", IsUnique = true)]
public partial class Bill
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? ExternalReferenceNumber { get; set; }

    [StringLength(200)]
    public string? ProcurementGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BillDate { get; set; }

    public int? PurchaseOrderId { get; set; }

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

    [InverseProperty("Bill")]
    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    [InverseProperty("Bill")]
    public virtual ICollection<BillPayment> BillPayments { get; set; } = new List<BillPayment>();

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("Bills")]
    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
