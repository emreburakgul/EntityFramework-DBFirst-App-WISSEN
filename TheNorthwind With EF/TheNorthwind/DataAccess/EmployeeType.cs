using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
