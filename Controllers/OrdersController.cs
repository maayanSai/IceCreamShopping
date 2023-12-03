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
        private readonly ApiServices _apiServices;


        public async Task<IActionResult> Index()
        {
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                var IsAddress = await cheakAddress(order.Street, order.City);
                var weather = await cheakWeather(order.City);
                var date = await cheakDate();


                if (IsAddress)
                {
                    ViewBag.Weather = weather.ToString("N2");
                    ViewBag.OrderDate = date;
                    return View(order);
                }
                else
                    ModelState.AddModelError("IsAddress", "The street and city not exict.");
            }
            return View(order);
        }

        private async Task<bool> cheakAddress(string street, string city)
        {
            var _apiServices = new ApiServices("acc_85435d24acba976");
            var answer = await _apiServices.CallServiceApi<bool>($"http://localhost:5103/api/address?CityName={Uri.EscapeDataString(city)}&StreetName={Uri.EscapeDataString(street)}");
            return answer;
        }

        private async Task<double> cheakWeather(string city)
        {
            var _apiServices = new ApiServices("5158de7d3dfa797d71b9f0179f23547a");
            var answer = await _apiServices.CallServiceApi<double>($"http://localhost:5103/api/Weather/{Uri.EscapeDataString(city)}");
            return answer;
        }
        private async Task<DateTime> cheakDate()
        {
            var _apiServices = new ApiServices("acc_85435d24acba976");
            var answer = await _apiServices.CallServiceApi<DateTime>($"http://localhost:5103/api/Hebcal");
            return answer;
        }
    }
}
