﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _services;

    public ProductsController(IProductService services)
    {
        _services = services;
    }

    public async Task <IActionResult> Index()
    {
        var customResponse = await _services.GetProductsWithCategory();
        return View(customResponse.Data);
    }
}
