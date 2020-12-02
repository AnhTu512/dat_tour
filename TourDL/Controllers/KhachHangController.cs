using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult booking()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KhachHang khachhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();



                long id = dao.Them(khachhang);
                if (id > 0)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khách Hàng không thành công !");
                }
            }
            return View("Index");
        }
    }
}