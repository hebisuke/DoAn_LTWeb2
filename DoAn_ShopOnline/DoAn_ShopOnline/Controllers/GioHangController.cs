using DoAn_ShopOnline.Models.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace DoAn_ShopOnline.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        
        // GET: GioHang
        public ActionResult Index()
        {
            ViewBag.TongTien = GioHangBUS.TongTien(User.Identity.GetUserId());
            return View(GioHangBUS.DanhSach(User.Identity.GetUserId()));
        }
        [HttpPost]
        public ActionResult Them(string masanpham,int soluong, int gia,string tensanpham)
        {
            try
            {
                GioHangBUS.Them(masanpham, User.Identity.GetUserId(),soluong,gia,tensanpham);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }
        [HttpPost]
        public ActionResult CapNhat(string masanpham, int soluong,int gia, string tensanpham)
        {
            try
            {
                GioHangBUS.CapNhat(masanpham, User.Identity.GetUserId(), soluong,gia,tensanpham);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }
        [HttpGet]
        public ActionResult Xoa(string masanpham)
        {
            try
            {
                GioHangBUS.Xoa(masanpham, User.Identity.GetUserId());
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }


        // update : công việc đầu tiên check <1
        //mỗi cái forecsh sẽ là 1 cái form chứ iduser , masp , so luong , sau do cap nhat lai so luong


        // xóa sản phảm đó dự vào mã sản phảm được chọn xóa , id đang thực hiện xóa
        // khi thanh toán , lưu toàn bộ xong db 
    }
}