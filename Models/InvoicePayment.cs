using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("InvoicePayment")]
[Index("Number", "TenantId", Name = "InvoicePaymentUniqueConstraint", IsUnique = true)]
public partial class InvoicePayment
{
    [Key]
    public int Id { get; set; }

    public int? InvoiceId { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? SalesGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    public int? CashBankId { get; set; }

    public double InvoiceAmount { get; set; }

    public double PaymentAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("CashBankId")]
    [InverseProperty("InvoicePayments")]
    public virtual CashBank CashBank { get; set; } = null!;

    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoicePayments")]
    public virtual Invoice Invoice { get; set; } = null!;
}
