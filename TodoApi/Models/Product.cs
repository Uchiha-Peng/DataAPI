using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public partial class Product
    {
        public int ProId { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ProName { get; set; }
        public string ProDescribe { get; set; }
        public decimal? Price { get; set; }
        public string PhotoSrc { get; set; }
        public int StoreCount { get; set; }
        public int? SalesCount { get; set; }
    }
}
