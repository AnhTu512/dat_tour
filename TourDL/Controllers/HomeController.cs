using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Tour = new TourDao().ListTour(6);
            ViewBag.DiaDiem = new DiaDiemDao().ListDiaDiem();
            return View();
        }
    }
}