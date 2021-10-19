using System;

namespace OrderApi.Model
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long? OrderNumber { get; set; }
        public decimal? Total { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Status { get; set; }
    }
}
