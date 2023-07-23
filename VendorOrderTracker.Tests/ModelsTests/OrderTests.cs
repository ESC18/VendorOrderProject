using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorModel;
using OrderModel;

namespace VendorOrderTracker.Tests.ModelTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void TestOrderDescription()
        {
            string description = "Test Order";
            Order order = new Order { Description = description };
            string result = order.Description;
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void TestOrderPrice()
        {
            int price = 100;
            Order order = new Order { Price = price };
            int result = order.Price;
            Assert.AreEqual(price, result);
        }

        [TestMethod]
        public void TestOrderVendorId()
        {
            int vendorId = 1;
            Order order = new Order { VendorId = vendorId };
            int result = order.VendorId;
            Assert.AreEqual(vendorId, result);
        }
    }
}
