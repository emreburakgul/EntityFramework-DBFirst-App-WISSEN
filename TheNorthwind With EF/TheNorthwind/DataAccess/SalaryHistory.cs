using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class SalaryHistory
    {
        public int SalaryHistory1 { get; set; }
        public int? EmployeeId { get; set; }
        public decimal? OldSalary { get; set; }
        public decimal? NewSalary { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
