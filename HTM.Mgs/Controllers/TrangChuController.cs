using HTM.Mgs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTM.Mgs.Controllers
{
    public class TrangChuController : BaseController
    {
        public ActionResult Index()
        {
            HTMDb db = new HTMDb();
            var YeuCauNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).Count();
            var YeuCauNguoiDungLenQuanTri = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == true).Count();
            var YeuCauDuyetLenPhongBan = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).Count();
            var SanPhamChoNhapKho = db.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == true && x.DaPheDuyet == false && x.SoLuong >= 0).Count();
            var SanPhamHetHang = db.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == true && x.SoLuong <= 0).Count();
            var YeuCauDaDuyet = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == true && x.TrangThai == true).Count();


            ViewBag.YeuCauNguoiDung = YeuCauNguoiDung.ToString();
            ViewBag.YeuCauNguoiDungLenQuanTri = YeuCauNguoiDungLenQuanTri.ToString();
            ViewBag.YeuCauDuyetLenPhongBan = YeuCauDuyetLenPhongBan.ToString();
            ViewBag.SanPhamChoNhapKho = SanPhamChoNhapKho.ToString();
            ViewBag.SanPhamHetHang = SanPhamHetHang.ToString();
            ViewBag.YeuCauDaDuyet = YeuCauDaDuyet.ToString();
            return View();
        }
    }
}
