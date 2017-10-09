using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Uid { get; set; }
        public int? StatusId { get; set; }
        public string ShoppingAddress { get; set; }
    }
}
