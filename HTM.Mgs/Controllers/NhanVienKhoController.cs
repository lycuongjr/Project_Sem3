using HTM.Mgs.Common;
using HTM.Mgs.Models;
using HTM.Mgs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTM.Mgs.Controllers
{
   public class NhanVienKhoController : BaseController
    {
        public ActionResult Index()
        {
            HTMDb db = new HTMDb();
            var DSYeuCauTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).Count();
            var DSYeuCauDaDuyetTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == true && x.TrangThai == true).Count();
            var SanPhamChoDuyet = db.SanPhams.Where(x => x.DaXoa == false && x.DaPheDuyet == false && x.TrangThai == true && x.DaNhapKho == true).Count();
            var SanPhamChoDuyetTrongKho = db.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == false && x.TrangThai == false).Count();
            ViewBag.DSYeuCauTuNguoiDung = DSYeuCauTuNguoiDung.ToString();
            ViewBag.DSYeuCauDaDuyetTuNguoiDung = DSYeuCauDaDuyetTuNguoiDung.ToString();
            ViewBag.SanPhamChoDuyet = SanPhamChoDuyet.ToString();
            ViewBag.SanPhamChoDuyetTrongKho = SanPhamChoDuyetTrongKho.ToString();
            return View();
        }
        public ActionResult Form(int? Id
          , string TenSanPham
          , string MaSanPham
          , string TieuDe
          , string MoTa
          , double? Gia
          , int? SoLuong
          , int? TheLoadId
          , string ChiTiet
           , string[] thumbnails
          )
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            SanPhamService _sp = new SanPhamService();
            Models.SanPham sp = _sp.FindByKeys(Id);
            sp.TenSanPham = TenSanPham;
            sp.MaSanPham = MaSanPham;
            sp.TieuDe = TieuDe;
            sp.MaSanPham = MoTa;
            sp.Gia = Gia;
            sp.NguoiTao = session.Name;
            sp.SoLuong = SoLuong;
            sp.TheLoaiId = TheLoadId;
            sp.ChiTiet = ChiTiet;
            sp.DaPheDuyet = true;
            sp.TrangThai = false;
            sp.DaNhapKho = false;

            sp.DaXoa = false;
            if (Id.HasValue)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    sp.Anh = string.Join(";", thumbnails);
                }
                sp.NguoiSua = session.Name;
                sp.NgaySua = DateTime.Now;
                _sp.Update(sp);
                setAlert("Thông tin sản phẩm đã được cập nhập", "success");
            }
            else
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    sp.Anh = string.Join(";", thumbnails);
                }
                sp.NgayTao = DateTime.Now;
                _sp.Insert(sp);
                setAlert("Thêm sản phẩm thành công", "success");
            }
            return RedirectToAction("Index");
        }
        public ActionResult DanhSachSanPhamChoDuyet()
        {
            HTMDb db = new HTMDb();
            var DSYeuCauTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == false && x.TrangThai == false).Count();
            var DSYeuCauDaDuyetTuNguoiDung = db.YeuCauNguoiDungs.Where(x => x.DaPheDuyet == true && x.TrangThai == true).Count();
            var SanPhamChoDuyet = db.SanPhams.Where(x => x.DaXoa == false && x.DaPheDuyet == false && x.TrangThai == true && x.DaNhapKho == true).Count();
            var SanPhamChoDuyetTrongKho = db.SanPhams.Where(x => x.DaXoa == false && x.DaNhapKho == false && x.TrangThai == false).Count();
            ViewBag.DSYeuCauTuNguoiDung = DSYeuCauTuNguoiDung.ToString();
            ViewBag.DSYeuCauDaDuyetTuNguoiDung = DSYeuCauDaDuyetTuNguoiDung.ToString();
            ViewBag.SanPhamChoDuyet = SanPhamChoDuyet.ToString();
            ViewBag.SanPhamChoDuyetTrongKho = SanPhamChoDuyetTrongKho.ToString();

            return View();
        }
    }
}
