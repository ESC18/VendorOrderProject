using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderModel;
using VendorModel;

public class OrdersController : Controller
{
    [HttpGet("/vendors/{vendorId}/orders")]
    public ActionResult Index(int vendorId)
    {
        Vendor vendor = VendorsController.VendorsList.Find(v => v.Id == vendorId);
        List<Order> orders = vendor?.Orders ?? new List<Order>();
        return View(orders);
    }

    [HttpGet("/vendors/{vendorId}/orders/create")]
    public ActionResult Create(int vendorId)
    {
        ViewData["VendorId"] = vendorId;
        return View();
    }

    [HttpPost("/vendors/{vendorId}/orders/create")]
    public ActionResult Create(int vendorId, Order order)
    {
        Vendor vendor = VendorsController.VendorsList.Find(v => v.Id == vendorId);
        if (vendor == null)
        {
            return NotFound();
        }
        order.Id = vendor.Orders.Count + 1;
        order.VendorId = vendorId;
        vendor.Orders.Add(order);
        return RedirectToAction("Index", new { vendorId = vendorId });
    }
}
