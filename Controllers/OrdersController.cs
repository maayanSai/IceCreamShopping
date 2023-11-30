using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Data;
using IceCreamsShopping.Models;

namespace IceCreamsShopping.Controllers
{
    public class OrdersController : Controller
    { 

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View();
                        
        }
    }
}
