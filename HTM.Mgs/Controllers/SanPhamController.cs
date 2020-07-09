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
    public class SanPhamController : BaseController
    {
        HTMDb db = new HTMDb();
        public ActionResult Index()
        {
            var SanPhamChoDuyet = db.SanPhams.Where(x => x.TrangThai == true && x.DaPheDuyet == false && x.DaXoa == false).Count();
            var SanPhamChoDuyetTrongKho = db.SanPhams.Where(x => x.TrangThai == true && x.DaPheDuyet == false && x.DaXoa == false).Count();
            ViewBag.SanPhamChoDuyet = SanPhamChoDuyet.ToString();
            ViewBag.SanPhamChoDuyetTrongKho = SanPhamChoDuyetTrongKho.ToString();
            return View();
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
        public ActionResult DanhSachSanPhamChoNhapKho()
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
        public ActionResult DanhSachSanPhamDuyetGanDay()
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
        public ActionResult DanhSachSanPhamTrongKho()
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
        public ActionResult DanhSachSanPhamHetHang()
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
     
        public ActionResult DSChoDuyetVaoKho()
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
        public PartialViewResult LoadDanhSanPham(string MaSanPham, string TenSanPham, int? PageCurrent, int? TheLoaiId)
        {

            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPham(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                , TheLoaiId
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = TenSanPham;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DanhSachSanPham", sp);
        }
        public PartialViewResult LoadDanhHetHang(string MaSanPham, string TenSanPham, int? PageCurrent)
        {
            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPhamHetHang(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = TenSanPham;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DanhSachSanPham", sp);
        }
        public PartialViewResult LoadDanhSanPhamChoDuyet(string MaSanPham, string TenSanPham, int? PageCurrent)
        {
            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPhamChoDuyet(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = TenSanPham;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DSChoDuyet", sp);
        }
        public PartialViewResult LoadDanhSanPhamChoNhapkho(string MaSanPham, string TenSanPham, int? PageCurrent)
        {
            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPhamChoNhapKho(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = TenSanPham;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DSChoNhapKho", sp);
        }
        public PartialViewResult _LoadDanhSanPhamDaXoa(string MaSanPham, string TenSanPham, int? PageCurrent)
        {
            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPhamDaXoa(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = TenSanPham;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView(sp);
        }

        public ActionResult Form(int? Id)
        {
            var sp = new Models.SanPham();
            if (Id.HasValue && Id != null)
            {
                var sanPham = new SanPhamService();
                sp = sanPham.FindByKeys(Id);
            }
            return View(sp);
        }
        public ActionResult DanhSachSanPhamDaXoa(string MaSanPham, string TenSanPham, int? PageCurrent)
        {
            var SanPhamChoDuyet = db.SanPhams.Where(x => x.TrangThai == true && x.DaPheDuyet == false && x.DaXoa == false).Count();
            var SanPhamChoDuyetTrongKho = db.SanPhams.Where(x => x.TrangThai == true && x.DaPheDuyet == false && x.DaXoa == false).Count();
            ViewBag.SanPhamChoDuyet = SanPhamChoDuyet.ToString();
            ViewBag.SanPhamChoDuyetTrongKho = SanPhamChoDuyetTrongKho.ToString();
            SanPhamService service = new SanPhamService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.SanPham> sp = service.GetListSanPhamDaXoa(MaSanPham
                , TenSanPham
                , pageNumber
                , 10
                );
            ViewBag.MaSanPham = MaSanPham;
            ViewBag.TenSanPham = MaSanPham;
            ViewBag.PageCurrent = PageCurrent;

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
            sp.MoTa = MoTa;
            sp.Gia = Gia;
            sp.NguoiTao = session.Name;
            sp.SoLuong = SoLuong;
            sp.TheLoaiId = TheLoadId;
            sp.ChiTiet = ChiTiet;
            if(session.NhomQuyenSuDungID == "ADMIN")
            {
                sp.DaPheDuyet = true;
                sp.TrangThai = true;
                sp.DaNhapKho = true;
            }else if(session.NhomQuyenSuDungID == "MOD")
            {
                sp.DaPheDuyet = false;
                sp.TrangThai = true;
                sp.DaNhapKho = true;

            }

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
        public PartialViewResult _SanPhamChiTiet(int? Id)
        {
            var sp = new Models.SanPham();
            if (Id.HasValue && Id != null)
            {
                var sanPham = new SanPhamService();
                sp = sanPham.FindByKeys(Id);
            }
            return PartialView(sp);
        }
        [HttpPost]
        public PartialViewResult _SanPhamChiTiet(int? Id
          , string TenSanPham
          , string MaSanPham
          , string TieuDe
          , string MoTa
          , double? Gia
          , int? SoLuong
          , int? TheLoadId
          , string ChiTiet
          , bool TrangThai
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
            sp.DaPheDuyet = false;
            sp.TrangThai = TrangThai;
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
            return PartialView();
        }
        public PartialViewResult _PheDuyetYeuCau(int? Id)
        {
            var sp = new Models.SanPham();
            if (Id.HasValue && Id != null)
            {
                var _sp = new SanPhamService();
                sp = _sp.FindByKeys(Id);
            }
            return PartialView(sp);
        }
        [HttpPost]
        public PartialViewResult _LoadDanhSachTheoLoai(int? TheloaiId)
        {
            TheLoaiService service = new TheLoaiService();

            ViewBag._LoadDanhSachTheoLoai = new SelectList(service.DSTheLoai(), "TheLoadId", "TenTheLoai", TheloaiId);
            return PartialView("_LoadDanhSachTheLoai");
        }
        public JsonResult _LoadDanhSachTheLoai(int? TheLoaiId)
        {
            TheLoaiService _service = new TheLoaiService();
            var data = _service.DSTheLoai();
            return Json(
                   data.Select(x => new { text = x.TenTheLoai, id = x.TheLoadId, selected = TheLoaiId == x.TheLoadId }).ToList()
              , JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangeStatus(int? id)
        {
            if (id.HasValue)
            {
                SanPhamService service = new SanPhamService();
                var sp = service.FindByKey(id.Value);
                if (sp != null)
                {
                    sp.TrangThai = sp.TrangThai.HasValue ? !sp.TrangThai : true;
                    service.Update(sp);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sinh viên không khả dung" });

        }
        public JsonResult PheDuyetYeuCauNhapKho(int? id)
        {
            if (id.HasValue)
            {
                SanPhamService service = new SanPhamService();
                var sp = service.FindByKey(id.Value);
                if (sp != null)
                {
                    sp.DaNhapKho = sp.DaNhapKho.HasValue ? !sp.DaNhapKho : true;
                    service.Update(sp);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sinh viên không khả dung" });
        }
        public JsonResult PheDuyetYeuCau(int? id)
        {
            if (id.HasValue)
            {
                SanPhamService service = new SanPhamService();
                var sp = service.FindByKey(id.Value);
                if (sp != null)
                {
                    sp.DaPheDuyet = sp.DaPheDuyet.HasValue ? !sp.DaPheDuyet : true;
                    service.Update(sp);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sản phẩm không khả dụng" });
        }
        public JsonResult Delete(int? id)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (id.HasValue)
            {
                SanPhamService service = new SanPhamService();
                var sp = service.FindByKey(id.Value);
                if (sp != null)
                {
                    sp.NguoiXoa = session.Name;
                    sp.DaXoa = sp.DaXoa.HasValue ? !sp.DaXoa : true;
                    sp.NgayXoa = DateTime.Now;
                    service.Update(sp);
                    return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(new { status = false, message = "Sinh viên không khả dung" });
        }
    }
}
