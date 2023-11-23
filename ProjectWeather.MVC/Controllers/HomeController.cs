using Microsoft.AspNetCore.Mvc;
using ProjectWeather.Domain.Entities;
using ProjectWeather.Infrastructure.Services;
using ProjectWeather.MVC.Models;

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
    }
}