using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class VwEmployeesInfo
    {
        public string FirstName { get; set; }
        public string BirthDate { get; set; }
        public string HomePhone { get; set; }
        public int? ReportsTo { get; set; }
        public string MenagerName { get; set; }
    }
}
