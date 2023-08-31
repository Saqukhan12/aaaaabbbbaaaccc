using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetCoreBoilerplate.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Access = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RouteAccess = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        IsOnline = table.Column<bool>(type: "bit", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        LoginCount = table.Column<int>(type: "int", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashBank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashBank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flavour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxRatePercentage = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesChannel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TaxRatePercentage = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ProductNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    ProductNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    CustomerNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    CustomerNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    SalesNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SalesNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    SalesNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    InvoiceNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    InvoiceNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    InvoiceNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    InvoicePaymentNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    InvoicePaymentNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    InvoicePaymentNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    VendorNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    VendorNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    VendorNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    PurchaseNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PurchaseNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    PurchaseNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    BillNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BillNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    BillNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    BillPaymentNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BillPaymentNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    BillPaymentNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    SalesDeliveryNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SalesDeliveryNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    SalesDeliveryNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    SalesReturnNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SalesReturnNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    SalesReturnNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    PurchaseReceiptNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PurchaseReceiptNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    PurchaseReceiptNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    PurchaseReturnNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PurchaseReturnNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    PurchaseReturnNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    PositiveAdjustmentNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PositiveAdjustmentNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    PositiveAdjustmentNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    NegativeAdjustmentNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NegativeAdjustmentNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    NegativeAdjustmentNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    TransferOrderNumberPrefix = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TransferOrderNumberUseDate = table.Column<bool>(type: "bit", nullable: true),
                    TransferOrderNumberLength = table.Column<short>(type: "smallint", nullable: false),
                    MaximumUser = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Uom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VersionInfo",
                columns: table => new
                {
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    AppliedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "CustomerContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerContact_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalesGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SalesChannelId = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    OtherCharge = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrder_SalesChannel_SalesChannelId",
                        column: x => x.SalesChannelId,
                        principalTable: "SalesChannel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(86)", maxLength: 86, nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LastDirectoryUpdate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserImage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<short>(type: "smallint", nullable: false),
                    IsTenantAdmin = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    IsImpersonate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "TenantId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InternalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UomId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ColourId = table.Column<int>(type: "int", nullable: true),
                    FlavourId = table.Column<int>(type: "int", nullable: true),
                    PurchasePrice = table.Column<double>(type: "float", nullable: false),
                    SalesPrice = table.Column<double>(type: "float", nullable: false),
                    PurchaseTaxId = table.Column<int>(type: "int", nullable: true),
                    SalesTaxId = table.Column<int>(type: "int", nullable: true),
                    MinimumQty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Flavour_FlavourId",
                        column: x => x.FlavourId,
                        principalTable: "Flavour",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_PurchaseTax_PurchaseTaxId",
                        column: x => x.PurchaseTaxId,
                        principalTable: "PurchaseTax",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_SalesTax_SalesTaxId",
                        column: x => x.SalesTaxId,
                        principalTable: "SalesTax",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Uom_UomId",
                        column: x => x.UomId,
                        principalTable: "Uom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProcurementGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    OtherCharge = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendorContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorContact_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NegativeAdjustment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NegativeAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NegativeAdjustment_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NegativeAdjustment_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositiveAdjustment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositiveAdjustment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositiveAdjustment_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositiveAdjustment_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransferOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalQty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    FromId = table.Column<int>(type: "int", nullable: true),
                    ToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_FromId",
                        column: x => x.FromId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransferOrder_Warehouse_ToId",
                        column: x => x.ToId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalesGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    OtherCharge = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalesGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    ShipperId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQtyDelivered = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDelivery_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesDelivery_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesDelivery_Shipper_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shipper",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesDelivery_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    PermissionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserPermissionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    PermissionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Granted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.UserPermissionId);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrder_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExternalReferenceNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProcurementGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    OtherCharge = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bill_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExternalReferenceNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProcurementGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQtyReceive = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReceipt_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReceipt_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReceipt_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NegativeAdjustmentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NegativeAdjustmentId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NegativeAdjustmentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NegativeAdjustmentDetail_NegativeAdjustment_NegativeAdjustmentId",
                        column: x => x.NegativeAdjustmentId,
                        principalTable: "NegativeAdjustment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NegativeAdjustmentDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositiveAdjustmentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositiveAdjustmentId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositiveAdjustmentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositiveAdjustmentDetail_PositiveAdjustment_PositiveAdjustmentId",
                        column: x => x.PositiveAdjustmentId,
                        principalTable: "PositiveAdjustment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PositiveAdjustmentDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransferOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferOrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferOrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransferOrderDetail_TransferOrder_TransferOrderId",
                        column: x => x.TransferOrderId,
                        principalTable: "TransferOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoicePayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalesGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CashBankId = table.Column<int>(type: "int", nullable: true),
                    InvoiceAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePayment_CashBank_CashBankId",
                        column: x => x.CashBankId,
                        principalTable: "CashBank",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoicePayment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesDeliveryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesDeliveryId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    QtyDelivered = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDeliveryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesDeliveryDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesDeliveryDetail_SalesDelivery_SalesDeliveryId",
                        column: x => x.SalesDeliveryId,
                        principalTable: "SalesDelivery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SalesGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesDeliveryId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQtyReturn = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturn_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesReturn_SalesDelivery_SalesDeliveryId",
                        column: x => x.SalesDeliveryId,
                        principalTable: "SalesDelivery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesReturn_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Qty = table.Column<double>(type: "float", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    BeforeTax = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BillPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProcurementGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CashBankId = table.Column<int>(type: "int", nullable: true),
                    BillAmount = table.Column<double>(type: "float", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillPayment_Bill_BillId",
                        column: x => x.BillId,
                        principalTable: "Bill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillPayment_CashBank_CashBankId",
                        column: x => x.CashBankId,
                        principalTable: "CashBank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReceiptDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReceiptId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    QtyReceive = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReceiptDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReceiptDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReceiptDetail_PurchaseReceipt_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "PurchaseReceipt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ProcurementGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PurchaseReceiptId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    TotalQtyReturn = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_PurchaseReceipt_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "PurchaseReceipt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReturn_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesReturnId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    QtyReturn = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesReturnDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalesReturnDetail_SalesReturn_SalesReturnId",
                        column: x => x.SalesReturnId,
                        principalTable: "SalesReturn",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseReturnDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseReturnId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    QtyReturn = table.Column<double>(type: "float", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InsertUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseReturnDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseReturnDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseReturnDetail_PurchaseReturn_PurchaseReturnId",
                        column: x => x.PurchaseReturnId,
                        principalTable: "PurchaseReturn",
                        principalColumn: "Id");
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "BillUniqueConstraint",
                table: "Bill",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_PurchaseOrderId",
                table: "Bill",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillId",
                table: "BillDetail",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_ProductId",
                table: "BillDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "BillPaymentUniqueConstraint",
                table: "BillPayment",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayment_BillId",
                table: "BillPayment",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayment_CashBankId",
                table: "BillPayment",
                column: "CashBankId");

            migrationBuilder.CreateIndex(
                name: "BrandUniqueConstraint",
                table: "Brand",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "CashBankUniqueConstraint",
                table: "CashBank",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "CategoryUniqueConstraint",
                table: "Category",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ColourUniqueConstraint",
                table: "Colour",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "CustomerUniqueConstraint",
                table: "Customer",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContact_CustomerId",
                table: "CustomerContact",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "FlavourUniqueConstraint",
                table: "Flavour",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "InvoiceUniqueConstraint",
                table: "Invoice",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SalesOrderId",
                table: "Invoice",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "InvoicePaymentUniqueConstraint",
                table: "InvoicePayment",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayment_CashBankId",
                table: "InvoicePayment",
                column: "CashBankId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayment_InvoiceId",
                table: "InvoicePayment",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "LocationUniqueConstraint",
                table: "Location",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NegativeAdjustment_LocationId",
                table: "NegativeAdjustment",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_NegativeAdjustment_WarehouseId",
                table: "NegativeAdjustment",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "NegativeAdjustmentUniqueConstraint",
                table: "NegativeAdjustment",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NegativeAdjustmentDetail_NegativeAdjustmentId",
                table: "NegativeAdjustmentDetail",
                column: "NegativeAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NegativeAdjustmentDetail_ProductId",
                table: "NegativeAdjustmentDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PositiveAdjustment_LocationId",
                table: "PositiveAdjustment",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PositiveAdjustment_WarehouseId",
                table: "PositiveAdjustment",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "PositiveAdjustmentUniqueConstraint",
                table: "PositiveAdjustment",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PositiveAdjustmentDetail_PositiveAdjustmentId",
                table: "PositiveAdjustmentDetail",
                column: "PositiveAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PositiveAdjustmentDetail_ProductId",
                table: "PositiveAdjustmentDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ColourId",
                table: "Product",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FlavourId",
                table: "Product",
                column: "FlavourId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PurchaseTaxId",
                table: "Product",
                column: "PurchaseTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SalesTaxId",
                table: "Product",
                column: "SalesTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeId",
                table: "Product",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UomId",
                table: "Product",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "ProductNameUniqueConstraint",
                table: "Product",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_VendorId",
                table: "PurchaseOrder",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "PurchaseOrderUniqueConstraint",
                table: "PurchaseOrder",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_ProductId",
                table: "PurchaseOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_PurchaseOrderId",
                table: "PurchaseOrderDetail",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipt_LocationId",
                table: "PurchaseReceipt",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipt_PurchaseOrderId",
                table: "PurchaseReceipt",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceipt_WarehouseId",
                table: "PurchaseReceipt",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "PurchaseReceiptUniqueConstraint",
                table: "PurchaseReceipt",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceiptDetail_ProductId",
                table: "PurchaseReceiptDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReceiptDetail_PurchaseReceiptId",
                table: "PurchaseReceiptDetail",
                column: "PurchaseReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_LocationId",
                table: "PurchaseReturn",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_PurchaseReceiptId",
                table: "PurchaseReturn",
                column: "PurchaseReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturn_WarehouseId",
                table: "PurchaseReturn",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "PurchaseReturnUniqueConstraint",
                table: "PurchaseReturn",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnDetail_ProductId",
                table: "PurchaseReturnDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturnDetail_PurchaseReturnId",
                table: "PurchaseReturnDetail",
                column: "PurchaseReturnId");

            migrationBuilder.CreateIndex(
                name: "PurchaseTaxUniqueConstraint",
                table: "PurchaseTax",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Role_TenantId",
                table: "Role",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "UQ_RolePerm_RoleId_PermKey",
                table: "RolePermission",
                columns: new[] { "RoleId", "PermissionKey" },
                unique: true,
                filter: "[RoleId] IS NOT NULL AND [PermissionKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "SalesChannelUniqueConstraint",
                table: "SalesChannel",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDelivery_LocationId",
                table: "SalesDelivery",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDelivery_SalesOrderId",
                table: "SalesDelivery",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDelivery_ShipperId",
                table: "SalesDelivery",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDelivery_WarehouseId",
                table: "SalesDelivery",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "SalesDeliveryUniqueConstraint",
                table: "SalesDelivery",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeliveryDetail_ProductId",
                table: "SalesDeliveryDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDeliveryDetail_SalesDeliveryId",
                table: "SalesDeliveryDetail",
                column: "SalesDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerId",
                table: "SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_SalesChannelId",
                table: "SalesOrder",
                column: "SalesChannelId");

            migrationBuilder.CreateIndex(
                name: "SalesOrderUniqueConstraint",
                table: "SalesOrder",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductId",
                table: "SalesOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_SalesOrderId",
                table: "SalesOrderDetail",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_LocationId",
                table: "SalesReturn",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_SalesDeliveryId",
                table: "SalesReturn",
                column: "SalesDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturn_WarehouseId",
                table: "SalesReturn",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "SalesReturnUniqueConstraint",
                table: "SalesReturn",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnDetail_ProductId",
                table: "SalesReturnDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesReturnDetail_SalesReturnId",
                table: "SalesReturnDetail",
                column: "SalesReturnId");

            migrationBuilder.CreateIndex(
                name: "SalesTaxUniqueConstraint",
                table: "SalesTax",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ShipperUniqueConstraint",
                table: "Shipper",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "SizeUniqueConstraint",
                table: "Size",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_TenantName",
                table: "Tenant",
                column: "TenantName",
                unique: true,
                filter: "[TenantName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_FromId",
                table: "TransferOrder",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrder_ToId",
                table: "TransferOrder",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "TransferOrderUniqueConstraint",
                table: "TransferOrder",
                columns: new[] { "Number", "TenantId" },
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderDetail_ProductId",
                table: "TransferOrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferOrderDetail_TransferOrderId",
                table: "TransferOrderDetail",
                column: "TransferOrderId");

            migrationBuilder.CreateIndex(
                name: "UomUniqueConstraint",
                table: "Uom",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_TenantId",
                table: "User",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_UserPerm_UserId_PermKey",
                table: "UserPermission",
                columns: new[] { "UserId", "PermissionKey" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [PermissionKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId_UserId",
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "UQ_UserRoles_UserId_RoleId",
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [RoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "VendorUniqueConstraint",
                table: "Vendor",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VendorContact_VendorId",
                table: "VendorContact",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "WarehouseUniqueConstraint",
                table: "Warehouse",
                columns: new[] { "Name", "TenantId" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "BillPayment");

            migrationBuilder.DropTable(
                name: "CustomerContact");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "InvoicePayment");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "NegativeAdjustmentDetail");

            migrationBuilder.DropTable(
                name: "PositiveAdjustmentDetail");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail");

            migrationBuilder.DropTable(
                name: "PurchaseReceiptDetail");

            migrationBuilder.DropTable(
                name: "PurchaseReturnDetail");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "SalesDeliveryDetail");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail");

            migrationBuilder.DropTable(
                name: "SalesReturnDetail");

            migrationBuilder.DropTable(
                name: "TransferOrderDetail");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "VendorContact");

            migrationBuilder.DropTable(
                name: "VersionInfo");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "CashBank");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "NegativeAdjustment");

            migrationBuilder.DropTable(
                name: "PositiveAdjustment");

            migrationBuilder.DropTable(
                name: "PurchaseReturn");

            migrationBuilder.DropTable(
                name: "SalesReturn");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TransferOrder");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "PurchaseReceipt");

            migrationBuilder.DropTable(
                name: "SalesDelivery");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Colour");

            migrationBuilder.DropTable(
                name: "Flavour");

            migrationBuilder.DropTable(
                name: "PurchaseTax");

            migrationBuilder.DropTable(
                name: "SalesTax");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Uom");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SalesChannel");
        }
    }
}
