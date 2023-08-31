using System;

namespace DotNetCoreBoilerplate.Common.DataTableDTO
{
    public class DataTableDTO
    {
        public string dataType { get; set; }
        public string draw { get; set; }
        public string sortColumn { get; set; }
        public string sortColumnDirection { get; set; }
        public int skip { get; set; }
        public int pageSize { get; set; }
        public int recordsTotal { get; set; }
        public string searchValue { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
