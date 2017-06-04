using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineConnection;
using DoAn_ShopOnline.Models;
using PagedList.Mvc;
using PagedList;
using DoAn_ShopOnline.Models.BUS;

namespace DoAn_ShopOnline.Controllers
{

    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(string timkiem, int page = 1, int pagesize = 3)
        {
            var db = TimKiemBUS.TimKiem(timkiem).ToPagedList(page, pagesize);
            return View(db);
        }
    }
}