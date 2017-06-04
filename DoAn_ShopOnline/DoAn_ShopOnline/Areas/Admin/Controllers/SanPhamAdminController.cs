using DoAn_ShopOnline.Models.BUS;
using PagedList;
using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace DoAn_ShopOnline.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPhamAdmin
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            
            return View(ShopOnlineBUS.DanhSachSP().ToPagedList(page, pagesize));
        }

        // GET: Admin/SanPhamAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public JsonResult SaveImages(string id, string images)
        {
            JavaScriptSerializer serizlizer = new JavaScriptSerializer();
            var listImages = serizlizer.Deserialize<List<string>>(images);

            XElement xElement = new XElement("Images");

            foreach (var item in listImages)
            {
                var subStringItem = item.Substring(22);
                xElement.Add(new XElement("Images", subStringItem));
            }
            if(listImages.Count()==0)
            {
                
                xElement.Add(new XElement("Images", "/Asset/data/images/default.png"));
            }
            try
            {
                ShopOnlineBUS.UpdateImages(id, xElement.ToString());
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false
                });
            }

        }
        // GET: Admin/SanPhamAdmin/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }

        // POST: Admin/SanPhamAdmin/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                sp.TinhTrang = "0";
                sp.SoLuongDaBan = 0;
                sp.LuotView = 0;
                sp.TinhTrang = "1";
                XElement xElement = new XElement("Images");
                xElement.Add(new XElement("Images", "/Asset/data/images/default.png"));
                sp.MoreImages = xElement.ToString();
                // TODO: Add insert logic here
                ShopOnlineBUS.InsertSP(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Edit/5
        public ActionResult Edit(String id)
        {
            ViewBag.MaNhaSanXuat = new SelectList(NhaSanXuatBUS.DanhSach(), "MaNhaSanXuat", "TenNhaSanXuat",ShopOnlineBUS.ChiTiet(id).MaNhaSanXuat);
            ViewBag.MaLoaiSanPham = new SelectList(LoaiSanPhamBUS.DanhSach(), "MaLoaiSanPham", "TenLoaiSanPham",ShopOnlineBUS.ChiTiet(id).MaLoaiSanPham);
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(String id, SanPham sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add update logic here
                sp.MoreImages = tam.MoreImages;
                if (sp.SoLuongDaBan>10000)
                {
                    sp.SoLuongDaBan = 0;
                }else { sp.SoLuongDaBan = tam.SoLuongDaBan; }
                if (sp.LuotView > 10000) { sp.LuotView = 0; } else { sp.LuotView = tam.LuotView; }
                sp.TinhTrang = tam.TinhTrang;
                ShopOnlineBUS.UpdateSP(id, sp);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/SanPhamAdmin/Delete/5
        public ActionResult Delete(String id)
        {
            return View(ShopOnlineBUS.ChiTiet(id));
        }

        // POST: Admin/SanPhamAdmin/Delete/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(String id,SanPham sp)
        {
            var tam = ShopOnlineBUS.ChiTiet(id);
            try
            {
                // TODO: Add delete logic here
                if (tam.SoLuongDaBan > 10000)
                {
                    tam.SoLuongDaBan = 0;
                }
                if (tam.LuotView > 10000) { tam.LuotView = 0; } 
                if(tam.TinhTrang == "1         ") { tam.TinhTrang = "0         "; }
                else
                {
                    tam.TinhTrang = "1         ";
                }

                ShopOnlineBUS.UpdateSP(id, tam);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
