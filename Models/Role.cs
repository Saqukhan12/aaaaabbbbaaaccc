using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }

    public int? TenantId { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    [ForeignKey("TenantId")]
    [InverseProperty("Roles")]
    public virtual Tenant Tenant { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
