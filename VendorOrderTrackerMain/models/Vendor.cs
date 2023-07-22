using System;
using System.Collections.Generic;
using OrderModel;

namespace VendorModel
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}