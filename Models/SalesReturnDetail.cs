using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("SalesReturnDetail")]
public partial class SalesReturnDetail
{
    [Key]
    public int Id { get; set; }

    public int? SalesReturnId { get; set; }

    public int? ProductId { get; set; }

    public double QtyReturn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SalesReturnDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("SalesReturnId")]
    [InverseProperty("SalesReturnDetails")]
    public virtual SalesReturn SalesReturn { get; set; } = null!;
}
