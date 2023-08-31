using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("RoleId", "UserId", Name = "IX_UserRoles_RoleId_UserId")]
[Index("UserId", "RoleId", Name = "UQ_UserRoles_UserId_RoleId", IsUnique = true)]
public partial class UserRole
{
    [Key]
    public long UserRoleId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoles")]
    public virtual User User { get; set; } = null!;
}
