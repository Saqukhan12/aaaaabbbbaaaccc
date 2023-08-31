using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreBoilerplate.Models;

public partial class Language
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string LanguageId { get; set; } = null!;

    [StringLength(50)]
    public string LanguageName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? InsertDate { get; set; }

    public int? InsertUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdateDate { get; set; }

    public int? UpdateUserId { get; set; }
}
