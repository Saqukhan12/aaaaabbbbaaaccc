using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("RoleId", "PermissionKey", Name = "UQ_RolePerm_RoleId_PermKey", IsUnique = true)]
public partial class RolePermission
{
    [Key]
    public long RolePermissionId { get; set; }

    public int? RoleId { get; set; }

    [StringLength(100)]
    public string PermissionKey { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("RolePermissions")]
    public virtual Role Role { get; set; } = null!;
}
