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

        private readonly OrdersManagerController _ordersManagerController;

        public OrdersController(OrdersManagerController ordersManagerController)
        {
            _ordersManagerController = ordersManagerController;
        }

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
        public async Task<IActionResult> Create(Order order, int Price, string Image, string Name)
        {
            if (ModelState.IsValid)
            {
                return await _ordersManagerController.Create(order);
            }
            else
            {
                var IsAddress = await cheakAddress(order.Street, order.City);
                var Weather = await cheakWeather(order.City);
                var date = await cheakDate();
                if (IsAddress)
                {


                    order.Weather = Weather.ToString("N2");
                    order.IsHoliday = date.IsHoliday;
                    order.OrderDate = date.time;
                    return RedirectToAction("Create", "Orders", new
                    {
                        image = Image,
                        price = Price,
                        name = Name,
                        firstName = order.FirstName,
                        lastName = order.LastName,
                        phone = order.Phone,
                        email = order.Email,
                        street = order.Street,
                        city = order.City,
                        weather = order.Weather,
                        holiday = order.IsHoliday,
                        day = order.OrderDate,
                    });
                }
                else
                {
                    ModelState.AddModelError("IsAddress", "The street and city not exist.");
                    return RedirectToAction("Create", "Orders", new
                    {
                        image = Image,
                        price = Price,
                        name = Name,
                        firstName = order.FirstName,
                        lastName = order.LastName,
                        phone = order.Phone,
                        email = order.Email,
                        street = order.Street,
                        city = order.City,

                    });

                }
            }


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
        private async Task<HebcalData> cheakDate()
        {
            var _apiServices = new ApiServices("acc_85435d24acba976");
            var answer = await _apiServices.CallServiceApi<HebcalData>("http://localhost:5103/api/Hebcal");
            return answer;
        }
    }
}
