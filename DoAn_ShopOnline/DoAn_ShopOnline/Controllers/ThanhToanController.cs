using DoAn_ShopOnline.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShopOnlineConnection;

namespace DoAn_ShopOnline.Controllers
{
    [Authorize]
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            List<GioHang> ds = GioHangBUS.DanhSach(User.Identity.GetUserId()).ToList();
            if(ds.Count()==0)
            {
                return RedirectToAction("../Shop/index");
            }
            return View(ds);
        }
    }
}