using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VendorModel;

public class VendorsController : Controller
{
    private static List<Vendor> _vendors = new List<Vendor>();

    // Add this property to expose the vendors list to other classes
    public static List<Vendor> VendorsList => _vendors;

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
        vendor.Id = _vendors.Count + 1;
        _vendors.Add(vendor);
        return RedirectToAction("Index");
    }
}
