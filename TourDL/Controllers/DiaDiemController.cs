using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Controllers
{
    public class DiaDiemController : Controller
    {
        // GET: DiaDiem
        public ActionResult Index()
        {
            ViewBag.DiaDiem = new DiaDiemDao().ListDiaDiem();
            return View();
        }
    }
}