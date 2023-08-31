using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Tenant")]
[Index("TenantName", Name = "IX_Tenant_TenantName", IsUnique = true)]
public partial class Tenant
{
    [Key]
    public int TenantId { get; set; }

    [StringLength(200)]
    public string TenantName { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(5)]
    public string Currency { get; set; } = null!;

    [StringLength(200)]
    public string? Street { get; set; }

    [StringLength(200)]
    public string? City { get; set; }

    [StringLength(200)]
    public string? State { get; set; }

    [StringLength(50)]
    public string? ZipCode { get; set; }

    [StringLength(50)]
    public string? Phone { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    [StringLength(5)]
    public string? ProductNumberPrefix { get; set; }

    public bool? ProductNumberUseDate { get; set; }

    public short ProductNumberLength { get; set; }

    [StringLength(5)]
    public string? CustomerNumberPrefix { get; set; }

    public bool? CustomerNumberUseDate { get; set; }

    public short CustomerNumberLength { get; set; }

    [StringLength(5)]
    public string? SalesNumberPrefix { get; set; }

    public bool? SalesNumberUseDate { get; set; }

    public short SalesNumberLength { get; set; }

    [StringLength(5)]
    public string? InvoiceNumberPrefix { get; set; }

    public bool? InvoiceNumberUseDate { get; set; }

    public short InvoiceNumberLength { get; set; }

    [StringLength(5)]
    public string? InvoicePaymentNumberPrefix { get; set; }

    public bool? InvoicePaymentNumberUseDate { get; set; }

    public short InvoicePaymentNumberLength { get; set; }

    [StringLength(5)]
    public string? VendorNumberPrefix { get; set; }

    public bool? VendorNumberUseDate { get; set; }

    public short VendorNumberLength { get; set; }

    [StringLength(5)]
    public string? PurchaseNumberPrefix { get; set; }

    public bool? PurchaseNumberUseDate { get; set; }

    public short PurchaseNumberLength { get; set; }

    [StringLength(5)]
    public string? BillNumberPrefix { get; set; }

    public bool? BillNumberUseDate { get; set; }

    public short BillNumberLength { get; set; }

    [StringLength(5)]
    public string? BillPaymentNumberPrefix { get; set; }

    public bool? BillPaymentNumberUseDate { get; set; }

    public short BillPaymentNumberLength { get; set; }

    [StringLength(5)]
    public string? SalesDeliveryNumberPrefix { get; set; }

    public bool? SalesDeliveryNumberUseDate { get; set; }

    public short SalesDeliveryNumberLength { get; set; }

    [StringLength(5)]
    public string? SalesReturnNumberPrefix { get; set; }

    public bool? SalesReturnNumberUseDate { get; set; }

    public short SalesReturnNumberLength { get; set; }

    [StringLength(5)]
    public string? PurchaseReceiptNumberPrefix { get; set; }

    public bool? PurchaseReceiptNumberUseDate { get; set; }

    public short PurchaseReceiptNumberLength { get; set; }

    [StringLength(5)]
    public string? PurchaseReturnNumberPrefix { get; set; }

    public bool? PurchaseReturnNumberUseDate { get; set; }

    public short PurchaseReturnNumberLength { get; set; }

    [StringLength(5)]
    public string? PositiveAdjustmentNumberPrefix { get; set; }

    public bool? PositiveAdjustmentNumberUseDate { get; set; }

    public short PositiveAdjustmentNumberLength { get; set; }

    [StringLength(5)]
    public string? NegativeAdjustmentNumberPrefix { get; set; }

    public bool? NegativeAdjustmentNumberUseDate { get; set; }

    public short NegativeAdjustmentNumberLength { get; set; }

    [StringLength(5)]
    public string? TransferOrderNumberPrefix { get; set; }

    public bool? TransferOrderNumberUseDate { get; set; }

    public short TransferOrderNumberLength { get; set; }

    public int MaximumUser { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    [InverseProperty("Tenant")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
