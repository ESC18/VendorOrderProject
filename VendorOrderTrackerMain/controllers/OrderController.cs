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
        return View(vendor);
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
        order.Id = vendor.Orders.Count + 1;
        vendor.Orders.Add(order);
        return RedirectToAction("Index", new { vendorId = vendorId });
    }
}
