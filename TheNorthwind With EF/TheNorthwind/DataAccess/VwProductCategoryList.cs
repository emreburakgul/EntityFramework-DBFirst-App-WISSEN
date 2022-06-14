using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class VwProductCategoryList
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
