using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class KhachSanController : BaseController
    {
        // GET: Admin/KhachSan
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhachSanDao();
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
            var khachsan = new KhachSanDao().ViewDetail(id);
            return View(khachsan);
        }


        [HttpPost]
        public ActionResult Create(KhachSan khachsan)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachSanDao();



                long id = dao.Them(khachsan);
                if (id > 0)
                {
                    return RedirectToAction("Index", "KhachSan");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm khách sạn không thành công !");
                }
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult Edit(KhachSan khachsan)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachSanDao();

                var result = dao.CapNhat(khachsan);

                if (result)
                {
                    return RedirectToAction("Index", "KhachSan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật khách sạn không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachSanDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}