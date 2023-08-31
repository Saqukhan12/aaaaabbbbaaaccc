using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("Email", Name = "IX_Users_Email", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string DisplayName { get; set; } = null!;

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(4)]
    public string Source { get; set; } = null!;

    [StringLength(86)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(10)]
    public string PasswordSalt { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? LastDirectoryUpdate { get; set; }

    [StringLength(100)]
    public string? UserImage { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InsertDate { get; set; }

    public int InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public short IsActive { get; set; }

    public bool IsTenantAdmin { get; set; }

    public int? TenantId { get; set; }

    [StringLength(255)]
    public string? IsImpersonate { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Users")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
