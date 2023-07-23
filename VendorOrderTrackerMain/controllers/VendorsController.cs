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

    [HttpGet("/vendors/{id}")]
    public ActionResult Details(int id)
    {
        Vendor vendor = _vendors.FirstOrDefault(v => v.Id == id);
        return View(vendor);
    }

    [HttpGet("/vendors/create")]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost("/vendors/create")]
    public ActionResult Create(Vendor vendor)
    {
        if (vendor != null)
        {
            vendor.Id = _vendors.Count + 1;
            _vendors.Add(vendor);
        }
        return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{vendorId}/createorder")]
    public ActionResult CreateOrder(int vendorId)
    {
        ViewData["VendorId"] = vendorId;
        return View();
    }

    [HttpPost("/vendors/{vendorId}/createorder")]
    public ActionResult CreateOrder(int vendorId, Order order)
    {
        Vendor vendor = VendorsList.Find(v => v.Id == vendorId);
        if (vendor == null)
        {
            return NotFound();
        }
        order.Id = vendor.Orders.Count + 1;
        order.VendorId = vendorId;
        vendor.Orders.Add(order);
        return RedirectToAction("Index");
    }
}
