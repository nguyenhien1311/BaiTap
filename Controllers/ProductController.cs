using BaiTap.Models.DataModels;
using BaiTap.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> p;
        IRepository<Category> cat;

        public ProductController()
        {
            p = new Repository<Product>();
            cat = new Repository<Category>();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(p.Get());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(p.Get(id));
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(cat.Get(),"Id","Name", p.Get(id).CategoryId);
            return View(p.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Product pd)
        {
            ViewBag.CategoryId = new SelectList(cat.Get(), "Id", "Name",pd.CategoryId);
            if (p.Edit(pd))
            {
                TempData["msg"] = "Cap nhat thanh cong";
            }
            else
            {
                TempData["msg"] = "Cap nhat that bai";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(cat.Get(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pd)
        {
            if (p.Add(pd))
            {
                TempData["msg"] = "Them san pham thanh cong";
            }
            else
            {
                TempData["msg"] = "Them san pham that bai";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (p.Remove(id))
            {
                TempData["msg"] = "Xoa pham thanh cong";
            }
            else
            {
                TempData["msg"] = "Xoa pham that bai";
            }
            return RedirectToAction("Index");
        }
    }
}