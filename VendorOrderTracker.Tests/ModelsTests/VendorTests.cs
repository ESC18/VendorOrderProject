using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorModel;
using OrderModel;

namespace VendorOrderTracker.Tests.ModelTests
{
    [TestClass]
    public class VendorTests
    {
        [TestMethod]
        public void TestVendorDescription()
        {
            string description = "Test Vendor";
            Vendor vendor = new Vendor { Description = description };
            string result = vendor.Description;
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void TestVendorOrders()
        {
            Vendor vendor = new Vendor();
            Order order1 = new Order();
            Order order2 = new Order();
            vendor.Orders.Add(order1);
            vendor.Orders.Add(order2);
            Assert.AreEqual(2, vendor.Orders.Count);
            Assert.AreEqual(order1, vendor.Orders[0]);
            Assert.AreEqual(order2, vendor.Orders[1]);
        }
    }
}
