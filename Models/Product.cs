using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Table("Product")]
[Index("Name", "TenantId", Name = "ProductNameUniqueConstraint", IsUnique = true)]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? Picture { get; set; }

    [StringLength(100)]
    public string? InternalCode { get; set; }

    [StringLength(100)]
    public string? Barcode { get; set; }

    public int? UomId { get; set; }

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }

    public int? SizeId { get; set; }

    public int? ColourId { get; set; }

    public int? FlavourId { get; set; }

    public double PurchasePrice { get; set; }

    public double SalesPrice { get; set; }

    public int? PurchaseTaxId { get; set; }

    public int? SalesTaxId { get; set; }

    public double MinimumQty { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int TenantId { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

    [ForeignKey("BrandId")]
    [InverseProperty("Products")]
    public virtual Brand Brand { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("ColourId")]
    [InverseProperty("Products")]
    public virtual Colour? Colour { get; set; }

    [ForeignKey("FlavourId")]
    [InverseProperty("Products")]
    public virtual Flavour? Flavour { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<NegativeAdjustmentDetail> NegativeAdjustmentDetails { get; set; } = new List<NegativeAdjustmentDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<PositiveAdjustmentDetail> PositiveAdjustmentDetails { get; set; } = new List<PositiveAdjustmentDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<PurchaseReceiptDetail> PurchaseReceiptDetails { get; set; } = new List<PurchaseReceiptDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; set; } = new List<PurchaseReturnDetail>();

    [ForeignKey("PurchaseTaxId")]
    [InverseProperty("Products")]
    public virtual PurchaseTax PurchaseTax { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<SalesDeliveryDetail> SalesDeliveryDetails { get; set; } = new List<SalesDeliveryDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; } = new List<SalesReturnDetail>();

    [ForeignKey("SalesTaxId")]
    [InverseProperty("Products")]
    public virtual SalesTax SalesTax { get; set; } = null!;

    [ForeignKey("SizeId")]
    [InverseProperty("Products")]
    public virtual Size? Size { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<TransferOrderDetail> TransferOrderDetails { get; set; } = new List<TransferOrderDetail>();

    [ForeignKey("UomId")]
    [InverseProperty("Products")]
    public virtual Uom Uom { get; set; } = null!;
}
