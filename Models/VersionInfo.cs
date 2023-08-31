using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

[Keyless]
[Table("VersionInfo")]
public partial class VersionInfo
{
    public long Version { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AppliedOn { get; set; }

    [StringLength(1024)]
    public string? Description { get; set; }
}
