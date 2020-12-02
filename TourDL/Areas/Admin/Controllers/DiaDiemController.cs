using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace TourDL.Areas.Admin.Controllers
{
    public class DiaDiemController : BaseController
    {
        // GET: Admin/DiaDiem
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DiaDiemDao();
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
            var diadiem = new DiaDiemDao().ViewDetail(id);
            return View(diadiem);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(DiaDiem diadiem)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiaDiemDao();



                long id = dao.Them(diadiem);
                if (id > 0)
                {
                    return RedirectToAction("Index", "DiaDiem");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm địa điểm không thành công !");
                }
            }
            return View("Index");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(DiaDiem diadiem)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiaDiemDao();

                var result = dao.CapNhat(diadiem);

                if (result)
                {
                    return RedirectToAction("Index", "DiaDiem");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật địa điểm không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DiaDiemDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}