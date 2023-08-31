using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Index("UserId", "PreferenceType", "Name", Name = "IX_UserPref_UID_PrefType_Name", IsUnique = true)]
public partial class UserPreference
{
    [Key]
    public int UserPreferenceId { get; set; }

    public long UserId { get; set; }

    [StringLength(100)]
    public string PreferenceType { get; set; } = null!;

    [StringLength(200)]
    public string Name { get; set; } = null!;

    public string? Value { get; set; }
}
