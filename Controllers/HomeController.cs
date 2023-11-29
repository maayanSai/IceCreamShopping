﻿using IceCreamsShopping.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IceCreamsShopping.Data;

namespace CloudComputingIceProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly Flavors _context;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Shop()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}