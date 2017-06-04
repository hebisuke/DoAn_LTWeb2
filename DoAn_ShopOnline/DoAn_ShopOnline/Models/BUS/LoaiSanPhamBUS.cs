using ShopOnlineConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_ShopOnline.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        //------------ kHACH hANG
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham where TinhTrang = '0         '");
        }
        public static IEnumerable<SanPham> ChiTiet(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<SanPham>("select * from SanPham where MaLoaiSanPham = '"+id+ "' AND TinhTrang = '0         '");
        }


        //--------------- ADMIN
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new ShopOnlineConnectionDB();
            return db.Query<LoaiSanPham>("select * from LoaiSanPham");
        }
        public static void InsertLSP( LoaiSanPham lsp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Insert(lsp);
        }
        public static LoaiSanPham ChiTietAdmin(String id)
        {
            var db = new ShopOnlineConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("select * from LoaiSanPham where MaLoaiSanPham = '" + id + "'");
        }
        public static void EditLSP(String id,LoaiSanPham lsp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Update(lsp,id);
        }
        public static void DeleteLSP(String id, LoaiSanPham lsp)
        {
            var db = new ShopOnlineConnectionDB();
            db.Update(lsp, id);
        }

    }
}