using BaiTap.Models.DataModels;
using BaiTap.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category> _ctx;

        public CategoryController()
        {
            _ctx = new Repository<Category>();
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(_ctx.Get());
        }

        [HttpGet]
        public ActionResult Details(int id) {
            return View(_ctx.Get(id));
        } 


        [HttpGet]
        public ActionResult Edit(int id) {
            return View(_ctx.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Category c)
        {
            if (_ctx.Edit(c))
            {
                TempData["msg"] = "Cap nhat loai san pham thanh cong";
            }
            else
            {
                TempData["msg"] = "Cap nhat loai san pham that bai";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            if (_ctx.Add(c))
            {
                TempData["msg"] = "Them loai san pham thanh cong";
            }
            else
            {
                TempData["msg"] = "Them loai san pham that bai";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            if (_ctx.Remove(id))
            {
                TempData["msg"] = "Xoa loai san pham thanh cong";
            }
            else
            {
                TempData["msg"] = "Xoa loai san pham that bai";
            }
            return RedirectToAction("Index");
        }
    }
}