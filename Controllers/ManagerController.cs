﻿using Microsoft.AspNetCore.Mvc;

namespace IceCreamsShopping.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
