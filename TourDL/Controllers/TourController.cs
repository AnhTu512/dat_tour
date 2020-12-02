using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Index()
        {
            ViewBag.Tour = new TourDao().ListTour(6);
            ViewBag.DetailTour = new TourDao().DetailTour();
            return View();
        }
        public ActionResult Detail(long id)
        {
            var tour = new TourDao().ViewDetail(id);
            ViewBag.Tour = new TourDao().ViewDetail(tour.ID);
            return View(tour);
        }
    }
}