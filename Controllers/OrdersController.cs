using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IceCreamsShopping.Data;
using IceCreamsShopping.Models;
using IceCreamsShopping.ApiService;

namespace IceCreamsShopping.Controllers
{
    public class OrdersController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Orders order)
        {
            if (ModelState.IsValid)
            {
                // Call the CheckAddress action to check if the address exists.
                var isAddressValid = await CheckAddress(order.City, order.Street);

                if (!isAddressValid)
                {
                    ModelState.AddModelError("Address", "City and Street do not exist.");
                }
            }
            return View(order);
        }

        private async Task<bool> CheckAddress(string city, string street)
        {
            var _apiServices = new ApiServices("acc_85435d24acba976");
            var answer = await _apiServices.CallServiceApi<bool>($"http://localhost:5103/api/checkAddress?city={Uri.EscapeDataString(city)}&street={Uri.EscapeDataString(street)}");
            return answer;
        }


    }



}
