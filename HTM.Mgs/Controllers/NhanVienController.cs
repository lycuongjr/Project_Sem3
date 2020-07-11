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
   public class NhanVienController : BaseController
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
        public ActionResult DanhSachYeuCau()
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
        public ActionResult DanhSachYeuCauQuanTri()
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
        public ActionResult DanhSachDaDuocDuyet(int? id)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            session.UserID = id;
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
        public ActionResult DanhSachDaYeuCau()
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
        public PartialViewResult _LoadDanhSachTheoLoai(int? TheloaiId, int? SanPhamId)
        {
            TheLoaiService service = new TheLoaiService();

            ViewBag._LoadDanhSachTheoLoai = new SelectList(service.DSTheLoai1(SanPhamId), "TheLoadId", "TenTheLoai", TheloaiId);
            return PartialView();
        }
        public PartialViewResult _LoadDanhSachTheoSanPham(int? SanPhamId)
        {
            SanPhamService service = new SanPhamService();

            ViewBag._LoadDanhSachSanPham = new SelectList(service.DSSanPham(), "SanPhamId", "TenSanPham", SanPhamId);
            return PartialView();
        }
        public ActionResult _Form(int? Id)
        {
            var _yc = new Models.YeuCauNguoiDung();
            if (Id.HasValue && Id != null)
            {
                var yc = new NhanVienService();
                _yc = yc.FindByKeys(Id);
            }
            return View(_yc);
        }
        [HttpPost]
        public ActionResult _Form(int? Id
          , string NoiDung
          , int? SanPhamId
          , int? TheLoaiID
          , int? SoLuong
          , double? ThanhTien        
          )
        {

            var session = (UserLogin)Session[CommonConstants.USER_SESSION];           
            NhanVienService _nv = new NhanVienService();
            Models.YeuCauNguoiDung nv = _nv.FindByKeys(Id);
            nv.NoiDung = NoiDung;
            nv.NguoiDungId = session.UserID;
            nv.SanPhamId = SanPhamId;
            nv.TheLoaiId = TheLoaiID;
            nv.SoLuong = SoLuong;        
            nv.NguoiDungId = session.UserID;
            if (session.NhomQuyenSuDungID == "EMPLOYEE")
            {
                nv.TrangThai = true;
            }
            else if(session.NhomQuyenSuDungID == "MEMBER")
            {
                nv.TrangThai = false;
            }           
            nv.DaPheDuyet = false;
            nv.SoLuong = SoLuong;
            nv.TenNguoiDung = session.Name;
            if (Id.HasValue)
            {
                
                _nv.Update(nv);
                setAlert("Sửa yêu cầu thành công", "success");
            }
            else
            {
                
                _nv.Insert(nv);
                setAlert("Gửi yêu cầu thành công", "success");
            }
            return RedirectToAction("Index");
        }


    }
}
