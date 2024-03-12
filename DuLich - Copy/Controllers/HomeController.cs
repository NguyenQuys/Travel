using DuLich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLich.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext("LAPTOP-ARKQSHH1\\KTEAM");
        public ActionResult Index()
        {
            return View(data.Tinhs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string province, DateTime checkInDay, DateTime checkOutDay)
        {
            var findProvince = data.Tinhs.Where(m=>m.Province==province);
            return View(findProvince);
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