using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_ShopOnline.Models.BUS
{
    public class TimKiemBUS
    {
        public static IEnumerable<SanPham> TimKiem(string TimKiem)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham where TenSanPham like '%" + TimKiem + "%'");
        }
    }
}