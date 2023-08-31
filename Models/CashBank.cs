using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("CashBank")]
[Index("Name", "TenantId", Name = "CashBankUniqueConstraint", IsUnique = true)]
public partial class CashBank
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(100)]
    public string? AccountNumber { get; set; }

    [StringLength(200)]
    public string? Street { get; set; }

    [StringLength(200)]
    public string? City { get; set; }

    [StringLength(200)]
    public string? State { get; set; }

    [StringLength(10)]
    public string? ZipCode { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("CashBank")]
    public virtual ICollection<BillPayment> BillPayments { get; set; } = new List<BillPayment>();

    [InverseProperty("CashBank")]
    public virtual ICollection<InvoicePayment> InvoicePayments { get; set; } = new List<InvoicePayment>();
}
