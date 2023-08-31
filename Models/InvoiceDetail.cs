using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("InvoiceDetail")]
public partial class InvoiceDetail
{
    [Key]
    public int Id { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public double Price { get; set; }

    public double Qty { get; set; }

    public double SubTotal { get; set; }

    public double Discount { get; set; }

    public double BeforeTax { get; set; }

    public double TaxPercentage { get; set; }

    public double TaxAmount { get; set; }

    public double Total { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Invoice Invoice { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("InvoiceDetails")]
    public virtual Product Product { get; set; } = null!;
}
