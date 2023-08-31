using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Invoice")]
[Index("Number", "TenantId", Name = "InvoiceUniqueConstraint", IsUnique = true)]
public partial class Invoice
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
    public DateTime InvoiceDate { get; set; }

    public int? SalesOrderId { get; set; }

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

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoicePayment> InvoicePayments { get; set; } = new List<InvoicePayment>();

    [ForeignKey("SalesOrderId")]
    [InverseProperty("Invoices")]
    public virtual SalesOrder SalesOrder { get; set; } = null!;
}
