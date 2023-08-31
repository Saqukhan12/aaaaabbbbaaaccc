using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("BillPayment")]
[Index("Number", "TenantId", Name = "BillPaymentUniqueConstraint", IsUnique = true)]
public partial class BillPayment
{
    [Key]
    public int Id { get; set; }

    public int? BillId { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? ProcurementGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    public int? CashBankId { get; set; }

    public double BillAmount { get; set; }

    public double PaymentAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("BillId")]
    [InverseProperty("BillPayments")]
    public virtual Bill Bill { get; set; } = null!;

    [ForeignKey("CashBankId")]
    [InverseProperty("BillPayments")]
    public virtual CashBank CashBank { get; set; } = null!;
}
