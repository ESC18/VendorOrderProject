using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VendorModel;
using OrderModel;

public class VendorsController : Controller
{
    private static List<Vendor> _vendors = new List<Vendor>();

    public static List<Vendor> VendorsList => _vendors;

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
        return View(_vendors);
    }

    [HttpGet("/vendors/create")]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost("/vendors/create")]
    public ActionResult CreateVendor(Vendor vendor)
    {
        vendor.Id = _vendors.Count + 1;
        _vendors.Add(vendor);        
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{vendorId}/createorder")]
    public ActionResult CreateOrder(int vendorId)
    {
        ViewData["VendorId"] = vendorId;
        return View();
    }

    [HttpPost("/vendors/{vendorId}/createorder")]
    public ActionResult CreateOrder(int vendorId, OrderModel.Order order)
    {
        Vendor vendor = VendorsList.Find(v => v.Id == vendorId);
        if (vendor == null)
        {
            return NotFound();
        }

        if (vendor.Orders == null)
        {
            vendor.Orders = new List<OrderModel.Order>();
        }

        order.Id = vendor.Orders.Count + 1;
        order.VendorId = vendorId;
        vendor.Orders.Add(order);
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{vendorId}")]
    public ActionResult Show(int vendorId)
    {
        Vendor vendor = VendorsList.Find(v => v.Id == vendorId);
        if (vendor == null)
        {
            return NotFound();
        }

        return View(vendor);
    }
}
