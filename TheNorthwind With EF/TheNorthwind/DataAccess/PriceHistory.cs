using System;
using System.Collections.Generic;

#nullable disable

namespace TheNorthwind.DataAccess
{
    public partial class PriceHistory
    {
        public int PriceHistoryId { get; set; }
        public string ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
        public DateTime? ChangeDate { get; set; }
    }
}
