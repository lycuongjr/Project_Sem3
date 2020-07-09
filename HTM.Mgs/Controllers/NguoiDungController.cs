using DataTables.AspNet.Core;
using HTM.Mgs.Common;
using HTM.Mgs.Helper;
using HTM.Mgs.Models;
using HTM.Mgs.Service;
using HTM.Mgs.UI;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
namespace HTM.Mgs.Controllers
{
    public class NguoiDungController : BaseController
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
        public PartialViewResult LoadDanhSachNguoiDung(string MaNhanVien, string HoVaTen, int? PageCurrent)
        {
            NguoiDungService service = new NguoiDungService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.NguoiDung> nguoidung = service.GetStudents(MaNhanVien
                , HoVaTen
                , pageNumber
                , 10
                );
            ViewBag.MaNhanVien = MaNhanVien;
            ViewBag.HoVaTen = HoVaTen;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DanhSachNguoiDung", nguoidung);
        }
        public PartialViewResult _Form(int? Id)
        {
            var nguoidung = new Models.NguoiDung();
            if (Id.HasValue && Id != null)
            {
                var _nguoidung = new NguoiDungService();
                nguoidung = _nguoidung.FindByKeys(Id);
            }
            return PartialView(nguoidung);
        }
        public ActionResult DanhSachNguoiDungDaXoa(string MaNhanVien, string HoVaTen, int? PageCurrent)
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
            NguoiDungService service = new NguoiDungService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.NguoiDung> nguoidung = service.GetDanhSachSVDaXoa(MaNhanVien
                , HoVaTen
                , pageNumber
                , 10
                );
            ViewBag.MaNhanVien = MaNhanVien;
            ViewBag.HoVaTen = HoVaTen;
            ViewBag.PageCurrent = PageCurrent;

            return View(nguoidung);
        }
        [HttpPost]
        public ActionResult _Form(int? Id
           , string MaNhanVien
           , string HoVaTen
           , string TenDangNhap
           , string MatKhau
           , string Email
           , string DienThoai
           , string CMT
           , string ChucVuId
           , string VanPhongId
           , string NgaySinh
           , string DiaChi
            , double? HanMuc
           , string AnhDaiDien
           , bool TrangThai
            , string[] thumbnails
           )
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            NguoiDungService _nguoidung = new NguoiDungService();
            Models.NguoiDung nguoidung = _nguoidung.FindByKeys(Id);
            nguoidung.MaNhanVien = MaNhanVien;
            nguoidung.HoVaTen = HoVaTen;
            nguoidung.TenDangNhap = TenDangNhap;
            nguoidung.MatKhau = EncryptHelper.EncryptMD5(MatKhau); ;
            nguoidung.Email = Email;
            nguoidung.AnhDaiDien = AnhDaiDien;
            nguoidung.NguoiTao = session.Name;
            nguoidung.SoCMT = CMT;
            nguoidung.GioiHan = HanMuc;
            if (!string.IsNullOrEmpty(NgaySinh))
                nguoidung.NgaySinh = ConvertEx.ToDate(NgaySinh);
            nguoidung.DiaChi = DiaChi;
            nguoidung.DienThoai = DienThoai;
            if (!string.IsNullOrEmpty(ChucVuId))
                nguoidung.ChucVuId = Convert.ToInt32(ChucVuId);
            if (!string.IsNullOrEmpty(VanPhongId))
                nguoidung.VanPhongId = Convert.ToInt32(VanPhongId);
            nguoidung.TrangThai = TrangThai;

            nguoidung.DaXoa = false;
            if (Id.HasValue)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    nguoidung.AnhDaiDien = string.Join(";", thumbnails);
                }
                nguoidung.GioiHan = HanMuc;
                nguoidung.NguoiSua = session.Name;
                nguoidung.NgaySua = DateTime.Now;
                _nguoidung.Update(nguoidung);
                setAlert("Thông tin người dùng đã được cập nhập", "success");
            }
            else
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    nguoidung.AnhDaiDien = string.Join(";", thumbnails);
                }
                nguoidung.GioiHan = 1500000;
                nguoidung.NgayTao = DateTime.Now;
                _nguoidung.Insert(nguoidung);
                setAlert("Thêm người dùng thành công", "success");
            }
            return RedirectToAction("Index");
        }
        public PartialViewResult _UpdatePhanQuyen(int? Id)
        {
            var nguoidung = new Models.NguoiDung();
            if (Id.HasValue && Id != null)
            {
                var _nguoidung = new NguoiDungService();
                nguoidung = _nguoidung.FindByKeys(Id);
            }
            return PartialView(nguoidung);
        }
        [HttpPost]
        public ActionResult _UpdatePhanQuyen(int? Id,
            string NhomQuyenSuDungID
           )
        {
            NguoiDungService _nguoidung = new NguoiDungService();
            Models.NguoiDung nguoidung = _nguoidung.FindByKeys(Id);
            nguoidung.NhomQuyenSuDungID = NhomQuyenSuDungID;
            if (Id.HasValue)
            {
                _nguoidung.Update(nguoidung);
                setAlert("Thông tin người dùng đã được cập nhập", "success");
            }
            else
            {
                _nguoidung.Insert(nguoidung);
                setAlert("Thêm người dùng thành công", "success");
            }
            return RedirectToAction("Index");
        }
        public JsonResult CheckTenTK(string TenDangNhap, int? NguoiDungId)
        {
            NguoiDungService _nguoidung = new NguoiDungService();
            var result = _nguoidung.CheckTrungTenTaiKhoan(TenDangNhap, NguoiDungId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult _LoadDanhSachChucVu(int? ChucVuId)
        {
            ChucVuService service = new ChucVuService();

            ViewBag._LoadDanhSachChucVu = new SelectList(service.DSChucVu(), "ChucVuId", "TenChucVu", ChucVuId);
            return PartialView("_LoadDanhSachChucVu");
        }
        public PartialViewResult _LoadDanhSachVanPhong(int? VanPhongId)
        {
            VanPhongService service = new VanPhongService();

            ViewBag._LoadDanhSachVanPhong = new SelectList(service.DSVanPhong(), "VanPhongId", "TenVanPhong", VanPhongId);
            return PartialView("_LoadDanhSachVanPhong");
        }
        public PartialViewResult _LoaDanhSachPhanQuyen(int? NhomQuyenSuDungId)
        {
            NhomQuyenSuDungService service = new NhomQuyenSuDungService();

            ViewBag._LoadDanhSachQuyen = new SelectList(service.DSQuyen(), "NhomQuyenSuDungID", "TenQuyenSuDung", NhomQuyenSuDungId);
            return PartialView("_LoadDanhSachQuyen");
        }
        public ActionResult ThongTinChiTiet(int? Id)
        {
            var nguoidung = new Models.NguoiDung();
            if (Id.HasValue && Id != null)
            {
                var _nguoidung = new NguoiDungService();
                nguoidung = _nguoidung.FindByKeys(Id);
            }
            return View(nguoidung);
        }
        public JsonResult ChangeStatus(int? id)
        {
            if (id.HasValue)
            {
                NguoiDungService service = new NguoiDungService();
                var student = service.FindByKey(id.Value);
                if (student != null)
                {
                    student.TrangThai = student.TrangThai.HasValue ? !student.TrangThai : true;
                    service.Update(student);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sinh viên không khả dung" });
        }
        public JsonResult Delete(int? id)
        {
            if (id.HasValue)
            {
                NguoiDungService service = new NguoiDungService();
                var student = service.FindByKey(id.Value);
                if (student != null)
                {
                    student.DaXoa = student.DaXoa.HasValue ? !student.DaXoa : true;
                    student.NgayXoa = DateTime.Now;
                    service.Update(student);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sinh viên không khả dung" });
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Login/Login");
        }
    }
}
