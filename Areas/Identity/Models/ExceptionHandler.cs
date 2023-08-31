using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBoilerplate.Identity.Models
{
    public class ExceptionHandler
    {
        [Key]
        public Guid ExceptionId { get; set; }
        [StringLength(70)]
        public string URL { get; set; }
        [StringLength(255)]
        public string ExceptionString { get; set; }
        public DateTime? Datetime { get; set; }

    }
}
