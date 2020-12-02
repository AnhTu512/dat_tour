using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: Admin/KhachHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhachHangDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khachhang = new KhachHangDao().ViewDetail(id);
            return View(khachhang);
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


        [HttpPost]
        public ActionResult Edit(KhachHang khachhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();

                var result = dao.CapNhat(khachhang);

                if (result)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Khách hàng không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachHangDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}