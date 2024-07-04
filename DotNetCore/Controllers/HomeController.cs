using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
        public ActionResult CreateCookie()
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}