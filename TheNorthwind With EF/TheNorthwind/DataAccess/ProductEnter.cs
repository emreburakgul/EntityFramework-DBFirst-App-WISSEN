using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class ProductEnter
    {
        public int ProductEnterId { get; set; }
        public int? ProductId { get; set; }
        public int? Amount { get; set; }
        public DateTime EnterDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
