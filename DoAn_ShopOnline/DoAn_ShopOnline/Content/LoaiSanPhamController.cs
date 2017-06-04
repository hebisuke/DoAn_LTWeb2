using DoAn_ShopOnline.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DoAn_ShopOnline.Content
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(String id, int page = 1, int pagesize = 3)
        {
            var ds = LoaiSanPhamBUS.ChiTiet(id).ToPagedList(page, pagesize);
            return View(ds);
        }
    }
}