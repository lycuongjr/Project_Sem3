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
    public class TheLoaiController : BaseController
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
        public PartialViewResult LoadDsTheLoai(string TenTheLoai, int? PageCurrent)
        {
            TheLoaiService service = new TheLoaiService();
            int pageNumber = PageCurrent ?? 1;
            IPagedList<Models.TheLoai> theloai = service.GetDsTheLoai(TenTheLoai
                , pageNumber
                , 10
                );
            ViewBag.TenTheLoai = TenTheLoai;
            ViewBag.PageCurrent = PageCurrent;
            return PartialView("_DanhSachTheLoai", theloai);
        }
        public PartialViewResult _Form(int? Id)
        {
            var tl = new Models.TheLoai();
            if (Id.HasValue && Id != null)
            {
                var theloai = new TheLoaiService();
                tl = theloai.FindByKeys(Id);
            }
            return PartialView(tl);
        }
        [HttpPost]
        public ActionResult _Form(int? Id
           , string TenTheLoai
           , string TieuDe
           , string MoTa         
           )
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            TheLoaiService _tl = new TheLoaiService();
            Models.TheLoai tl = _tl.FindByKeys(Id);
            tl.TenTheLoai = TenTheLoai;
            tl.TieuDe = TieuDe;
            tl.MoTa = MoTa;
            if (Id.HasValue)
            {
                tl.NguoiSua = session.Name;
                tl.NgaySua = DateTime.Now;
                _tl.Update(tl);
                setAlert("Thông tin sản phẩm đã được cập nhập", "success");
            }
            else
            {
                tl.NgayTao = DateTime.Now;
                _tl.Insert(tl);
                setAlert("Thêm sản phẩm thành công", "success");
            }
            return RedirectToAction("Index");
        }
    }
}
