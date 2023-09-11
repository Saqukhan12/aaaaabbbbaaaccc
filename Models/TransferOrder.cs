using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("TransferOrder")]
[Index("Number", "TenantId", Name = "TransferOrderUniqueConstraint", IsUnique = true)]
public partial class TransferOrder 
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Number { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransferDate { get; set; }

   

    public double TotalQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("FromId")]
    [InverseProperty("TransferOrderFroms")]
    public virtual Warehouse From { get; set; } = null!;
    public int? FromId { get; set; }


    [ForeignKey("ToId")]
    [InverseProperty("TransferOrderTos")]
    public virtual Warehouse To { get; set; } = null!;
    public int? ToId { get; set; }

    [InverseProperty("TransferOrder")]
    public virtual ICollection<TransferOrderDetail> TransferOrderDetails { get; set; } = new List<TransferOrderDetail>();
}
