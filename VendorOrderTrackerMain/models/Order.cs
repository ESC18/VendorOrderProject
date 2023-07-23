using System;
using VendorModel;

namespace OrderModel
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
