using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        // GET: Admin/TinTuc
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TinTucDao();
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
            var tintuc = new TinTucDao().ViewDetail(id);
            return View(tintuc);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();

                

                long id = dao.Them(tintuc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tin tức không thành công !");
                }
            }
            return View("Index");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();
               
                var result = dao.CapNhat(tintuc);

                if (result)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TinTucDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}