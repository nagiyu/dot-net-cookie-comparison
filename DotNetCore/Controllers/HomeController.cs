using DotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // 既存のクッキーを確認
            if (Request.Cookies.TryGetValue("MyTestCookie", out string cookieValue))
            {
                ViewBag.CookieValue = cookieValue;
            }
            else
            {
                ViewBag.CookieValue = "No cookie found.";
            }

            return View();
        }

        [HttpPost]
        public IActionResult CreateCookie()
        {
            // クッキーの作成と設定
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(10) // 10秒後に期限切れ
            };
            Response.Cookies.Append("MyTestCookie", "Hello, this is a test cookie!", cookieOptions);

            // クッキーの内容をViewBagに設定
            ViewBag.CookieValue = "Hello, this is a test cookie!";

            return View("Index");
        }

        public IActionResult Privacy()
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
