using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("UserId", "PermissionKey", Name = "UQ_UserPerm_UserId_PermKey", IsUnique = true)]
public partial class UserPermission 
{
    [Key]
    public long UserPermissionId { get; set; }

    public int? UserId { get; set; }

    [StringLength(100)]
    public string PermissionKey { get; set; } = null!;

    [Required]
    public bool? Granted { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserPermissions")]
    public virtual User User { get; set; } = null!;
}
