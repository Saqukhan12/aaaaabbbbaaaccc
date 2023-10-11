using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreBoilerplate.Models
{
    public class SalesChannelDTO
    {
        //[Key]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? InsertDate { get; set; }

        //[InverseProperty("SalesChannel")]
        //public virtual ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();
        public string button { get; set; }
    }
}