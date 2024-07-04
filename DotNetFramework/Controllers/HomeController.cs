using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // 既存のクッキーを確認
            HttpCookie myCookie = Request.Cookies["MyTestCookie"];
            if (myCookie != null)
            {
                ViewBag.CookieValue = myCookie.Value;
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
            HttpCookie myCookie = new HttpCookie("MyTestCookie");
            myCookie.Value = "Hello, this is a test cookie!";
            myCookie.Expires = DateTime.Now.AddSeconds(10); // 10秒後に期限切れ
            Response.Cookies.Set(myCookie);

            // クッキーの内容をViewBagに設定
            ViewBag.CookieValue = myCookie.Value;
            ViewBag.CookieExpires = myCookie.Expires.ToString();

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