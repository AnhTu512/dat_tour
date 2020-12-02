using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class DichVuController : BaseController
    {
        // GET: Admin/DichVu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DichVuDao();
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
            var dichvu = new DichVuDao().ViewDetail(id);
            return View(dichvu);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                var dao = new DichVuDao();



                long id = dao.Them(dichvu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "DichVu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm dịch vụ không thành công !");
                }
            }
            return View("Index");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(DichVu dichvu)
        {
            if (ModelState.IsValid)
            {
                var dao = new DichVuDao();

                var result = dao.CapNhat(dichvu);

                if (result)
                {
                    return RedirectToAction("Index", "DichVu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật dịch vụ không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DichVuDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}