using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class TourController : BaseController
    {
        // GET: Admin/Tour
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TourDao();
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
            var tour = new TourDao().ViewDetail(id);
            return View(tour);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                var dao = new TourDao();



                long id = dao.Them(tour);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Tour");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm tour không thành công !");
                }
            }
            return View("Index");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                var dao = new TourDao();

                var result = dao.CapNhat(tour);

                if (result)
                {
                    return RedirectToAction("Index", "Tour");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tour không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TourDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}