using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Newtonsoft.Json;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Services;
using ProjectWeather.MVC.Models;
using System.Text;

namespace ProjectWeather.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClientService _httpClientService;

        public HomeController(ILogger<HomeController> logger, HttpClientService httpClientService)
        {
            _logger = logger;
            _httpClientService = httpClientService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeModel();
            var url = "https://localhost:7242/api/v1/Weather";
            model.Weathers = await _httpClientService.Get<List<Weather>>(url);
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var url = $"https://localhost:7242/api/v1/Weather/{id}";
            var result = await _httpClientService.Delete(url);
            TempData["msg"] = "Success deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = new EditWeatherModel();
            var url = $"https://localhost:7242/api/v1/Weather/{id}";
            model.weather = await _httpClientService.Get<Weather>(url);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Weather weather)
        {
            EditWeatherModel model = new();
            model.weather = weather;
            var url = "https://localhost:7242/api/v1/Weather";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var result = _httpClientService.Update(url, content);
            TempData["msg"] = "Success edited";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Preview(string id)
        {
            var model = new EditWeatherModel();
            var url = $"https://localhost:7242/api/v1/Weather/{id}";
            model.weather = await _httpClientService.Get<Weather>(url);
            return View(model);
        }
    }
}