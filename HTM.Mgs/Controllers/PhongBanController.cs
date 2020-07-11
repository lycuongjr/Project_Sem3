using HTM.Mgs.Common;
using HTM.Mgs.Models;
using HTM.Mgs.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTM.Mgs.Controllers
{
  public class PhongBanController : BaseController
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
        public ActionResult DanhSachCacYeuCauDaThongQua()
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
        public ActionResult Form(int? Id)
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
            var sp = new Models.SanPham();
            if (Id.HasValue && Id != null)
            {
                var sanPham = new SanPhamService();
                sp = sanPham.FindByKeys(Id);
            }
            return View(sp);
        }
        [HttpPost]
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
        public PartialViewResult _DSYeuCauChoDuyet(int? PageCurrent)
        {
            NhanVienService service = new NhanVienService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.YeuCauNguoiDung> yeucau = service.GetListYeuCauNguoiDung(
                 pageNumber
                , 10
                );
            ViewBag.PageCurrent = PageCurrent;

            return PartialView(yeucau);
        }
        public PartialViewResult _LoadDanhSachChoPheDuyetQuanTri(int? PageCurrent)
        {
            NhanVienService service = new NhanVienService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.YeuCauNguoiDung> yeucau = service.GetListYeuCauNguoiDungQuanTri(
                 pageNumber
                , 10
                );
            ViewBag.PageCurrent = PageCurrent;

            return PartialView(yeucau);
        }
        
        public PartialViewResult _DSYeuCauDaDuyet(int? PageCurrent)
        {

            NhanVienService service = new NhanVienService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.YeuCauNguoiDung> yeucau = service.GetListYeuCauDaDuyet(
                 pageNumber
                , 10

                );
            ViewBag.PageCurrent = PageCurrent;

            return PartialView(yeucau);
        }
        public PartialViewResult _YeuCauChiTiet(int? id)
        {
            var yc = new Models.YeuCauNguoiDung();
            if (id.HasValue && id != null)
            {
                var _yc = new NhanVienService();
                yc = _yc.FindByKeys(id);
            }

            return PartialView(yc);
        }
        
        public JsonResult PheDuyetYeuCau(int? id)
        {
            if (id.HasValue)
            {
                NhanVienService service = new NhanVienService();
                var nv = service.FindByKey(id.Value);
                if (nv != null)
                {
                    nv.DaPheDuyet = nv.DaPheDuyet.HasValue ? !nv.DaPheDuyet : true;
                    service.Update(nv);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sản phẩm không khả dụng" });
        }
        public JsonResult PheDuyetYeuCauPhongBan(int? id)
        {
            if (id.HasValue)
            {
                NhanVienService service = new NhanVienService();
                var nv = service.FindByKey(id.Value);
                if (nv != null)
                {
                    nv.TrangThai = nv.TrangThai.HasValue ? !nv.TrangThai : true;
                    service.Update(nv);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Không khả dụng" });
        }
        
    }
}
