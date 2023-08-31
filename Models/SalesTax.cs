using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesTax")]
[Index("Name", "TenantId", Name = "SalesTaxUniqueConstraint", IsUnique = true)]
public partial class SalesTax
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    public double TaxRatePercentage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("SalesTax")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
