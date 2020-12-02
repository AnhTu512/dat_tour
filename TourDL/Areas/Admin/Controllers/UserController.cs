using Model.Dao;
using Model.EF;
using QuanLiBenhNhanNoiTru.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourDL.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new TaiKhoanDao();
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
            var user = new TaiKhoanDao().ViewDetail(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();

                var encryptedMD5Pas = Encryptor.MD5Hash(user.UserPass);
                user.UserPass = encryptedMD5Pas;

                long id = dao.Them(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công !");
                }
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult Edit(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                if (!string.IsNullOrEmpty(user.UserPass))
                {
                    var encryptedMD5Pas = Encryptor.MD5Hash(user.UserPass);
                    user.UserPass = encryptedMD5Pas;
                }
                var result = dao.CapNhat(user);

                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công !");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TaiKhoanDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}