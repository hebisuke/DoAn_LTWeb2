using DoAn_ShopOnline.Models.BUS;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DoAn_ShopOnline.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index(int page = 1, int pagesize = 3)
        {
            var db = ShopOnlineBUS.DanhSach().ToPagedList(page, pagesize);
            return View(db);
        }

        // GET: Shop/Details/5
        public ActionResult Details(String id,int page =1, int pagesize =3)
        {
            var db = ShopOnlineBUS.ChiTiet(id);
            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            return View(db);
        }
        public JsonResult LoadImages(string id)
        {
            var product = ShopOnlineBUS.ChiTiet(id);
            var images = product.MoreImages;
            XElement xImages = XElement.Parse(images);
            List<string> listImageReturn = new List<string>();

            foreach (XElement element in xImages.Elements())
            {
                listImageReturn.Add(element.Value);
            }
            return Json(new
            {
                data = listImageReturn
            }, JsonRequestBehavior.AllowGet);
        }
        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
