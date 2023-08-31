using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBoilerplate.Common.BaseEntity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(256)]
        [DisplayName("User Stamp")]
        public string UserStamp { get; set; }

        [MaxLength(256)]
        [DisplayName("By")]
        public string CreatedBy { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        [DisplayName("Update By")]
        public string UpdatedBy { get; set; }
        [DisplayName("Update Date")]
        public DateTime? UpdatedDate { get; set; }

        public bool? IsSoftDeleted { get; set; }
    }

    public class SelectListModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class SelectListModelManualId
    {
        [HiddenInput(DisplayValue = false)]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class BaseSelectList
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
    }

    //Guid and Bases select list 
    public class GUBaseSelectList
    {
        public string Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
    }
}
