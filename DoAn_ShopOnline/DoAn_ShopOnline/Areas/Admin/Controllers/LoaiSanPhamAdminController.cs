using DoAn_ShopOnline.Models.BUS;
using PagedList;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_ShopOnline.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        // GET: Admin/LoaiSanPhamAdmin
        public ActionResult Index(int page = 1, int pagesize =5)
        {
            var db = LoaiSanPhamBUS.DanhSachAdmin().ToPagedList(page,pagesize);
            return View(db);
        }

        // GET: Admin/LoaiSanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPhamAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiSanPhamBUS.InsertLSP(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            // load db theo id
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add update logic here
                LoaiSanPhamBUS.EditLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/XoaTamThoi/5
        public ActionResult XoaTamThoi(String id)
        {
            var db = LoaiSanPhamBUS.ChiTietAdmin(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPhamAdmin/XoaTamThoi/5
        [HttpPost]
        public ActionResult XoaTamThoi(String id, LoaiSanPham lsp)
        {
            try
            {
                // TODO: Add delete logic here
                lsp.TinhTrang = "1";
                LoaiSanPhamBUS.EditLSP(id, lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Admin/LoaiSanPhamAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoaiSanPhamAdmin/Delete/5
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
