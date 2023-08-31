using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("ApplicationName", "DeletionDate", "CreationDate", Name = "IX_Exceptions_App_Del_Cre", IsDescending = new[] { false, false, true })]
[Index("Guid", "ApplicationName", "DeletionDate", "CreationDate", Name = "IX_Exceptions_GUID_App_Del_Cre", IsDescending = new[] { false, false, false, true })]
[Index("ErrorHash", "ApplicationName", "CreationDate", "DeletionDate", Name = "IX_Exceptions_Hash_App_Cre_Del", IsDescending = new[] { false, false, true, false })]
public partial class Exception
{
    [Key]
    public long Id { get; set; }

    [Column("GUID")]
    public Guid Guid { get; set; }

    [StringLength(50)]
    public string ApplicationName { get; set; } = null!;

    [StringLength(50)]
    public string MachineName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [StringLength(100)]
    public string Type { get; set; } = null!;

    [Required]
    public bool? IsProtected { get; set; }

    [StringLength(100)]
    public string? Host { get; set; }

    [StringLength(500)]
    public string? Url { get; set; }

    [Column("HTTPMethod")]
    [StringLength(10)]
    public string? Httpmethod { get; set; }

    [Column("IPAddress")]
    [StringLength(40)]
    public string? Ipaddress { get; set; }

    [StringLength(100)]
    public string? Source { get; set; }

    [StringLength(1000)]
    public string? Message { get; set; }

    public string? Detail { get; set; }

    public int? StatusCode { get; set; }

    [Column("SQL")]
    public string? Sql { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public string? FullJson { get; set; }

    public int? ErrorHash { get; set; }

    public int DuplicateCount { get; set; }
}
